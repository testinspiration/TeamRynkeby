﻿using System.Collections.Generic;
using System.Linq;

namespace EventBooking.Controllers.ViewModels
{

    public class  LandingPageModel
    {
        public bool IsNobody { get; set; }
        public int SelectedTeamId { get; set; } 
        public IEnumerable<ActivityModel> Activities { get; private set; }

        public LandingPageModel(IEnumerable<Data.Activity> activitiesData)
        {
            this.Activities = activitiesData.Select(AsActivityModel);
        }

        private static ActivityModel AsActivityModel(Data.Activity activityData)
        {
            return new ActivityModel(activityData);
        }
    }

}