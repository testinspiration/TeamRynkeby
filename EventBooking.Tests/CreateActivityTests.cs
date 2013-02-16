﻿using System;
using System.Web.Mvc;
using EventBooking.Controllers;
using EventBooking.Controllers.ViewModels;
using EventBooking.Data;
using EventBooking.Data.Repositories;
using EventBooking.Services;
using NUnit.Framework;

namespace EventBooking.Tests
{
	[SetUpFixture]
	internal class ClassSetup
	{
		[SetUp]
		public void Setup()
		{
			EventBookingMapper.SetupMappers();
		}
	}

	[TestFixture]
	public class CreateActivityTests
	{
		[SetUp]
		public void SetUp()
		{
			SecurityService = new MockupSecurityService {ReturnUser = new User {Team = new Team {Name = "The team"}}};
		}

		public static readonly DateTime Tomorrow = DateTime.Now.AddDays(1);
		public static readonly DateTime Yesterday = DateTime.Now.AddDays(-1);

		protected MockupSecurityService SecurityService { get; set; }

		private static ActionResult CreateValidActivity(ActivityControllerShunt controller)
		{
			return controller.Create(NewModel());
		}

		private static CreateActivityModel NewModel()
		{
			return new CreateActivityModel
				{
					Name = "Name",
					Date = Tomorrow,
					Description = "Description",
					Summary = "Summary",
					Type = ActivityType.Preliminary,
					Session = new SessionModel { FromTime = Tomorrow.AddHours( 10 ), ToTime = Tomorrow.AddHours( 11 ), VolunteersNeeded = 2 }
				};
		}

		[Test]
		public void GivenDataForNewActivityIsPersisted()
		{
			var controller = CreateController();

			CreateValidActivity(controller);

			Assert.IsNotNull(controller.CreatedActivity);
			Assert.AreEqual("Name", controller.CreatedActivity.Name);
			Assert.AreEqual(Tomorrow, controller.CreatedActivity.Date);
			Assert.AreEqual("Description", controller.CreatedActivity.Description);
			Assert.AreEqual("Summary", controller.CreatedActivity.Summary);
			Assert.AreEqual(ActivityType.Preliminary, controller.CreatedActivity.Type);
			Assert.AreEqual(SecurityService.ReturnUser.Team.Name, controller.CreatedActivity.OrganizingTeam.Name);
		}

		[Test]
		public void RedirectsToHomeAfterSuccessfulCreation()
		{
			var controller = CreateController();

			var result = CreateValidActivity(controller) as RedirectToRouteResult;

			Assert.NotNull(result);
			Assert.AreEqual("Index", result.RouteValues["Action"]);
			Assert.AreEqual("Home", result.RouteValues["controller"]);
		}

		[Test, Ignore]
		public void StaysOnViewIfTryingToCreateActivity_ForYesterday()
		{
			var controller = CreateController();
			CreateActivityModel forYesterday = NewModel();
			forYesterday.Date = Yesterday;

			ActionResult result = controller.Create(forYesterday);

			Assert.NotNull(result);
			Assert.IsInstanceOf<ViewResult>(result);
		}

		private ActivityControllerShunt CreateController()
		{
			return new ActivityControllerShunt(new ActivityRepositoryShunt(), SecurityService);
		}
	}

	public class ActivityRepositoryShunt : ActivityRepository
	{
		public ActivityRepositoryShunt()
			: base(null)
		{
		}
	}

	public class ActivityControllerShunt : ActivityController
	{
		public ActivityControllerShunt(ActivityRepository activityRepository, ISecurityService securityService)
			: base(securityService, activityRepository)
		{
		}

		public Activity CreatedActivity { get; set; }

		protected override void StoreActivity(Activity activity)
		{
			CreatedActivity = activity;
		}
	}
}