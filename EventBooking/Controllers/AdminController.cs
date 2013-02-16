﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventBooking.Controllers.ViewModels;
using EventBooking.Data;

namespace EventBooking.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            AdministratorPageModel model = new AdministratorPageModel(new List<Team>()
                {
                    new Team()
                        {
                                Activities = null,
                                Id = 1,
                                Name = "Team Lund",
                                Volunteers = new Collection<User>()
                                    {
                                        new User()
                                            {
                                                Id = 1,
                                                Name = "Fulhacke Fulhacksson"
                                                
                                            }
                                    }

                        },

                     new Team()
                        {
                                Activities = null,
                                Id = 1,
                                Name = "Team Stockholm",
                                Volunteers = new Collection<User>()
                                    {
                                        new User()
                                            {
                                                Id = 1,
                                                Name = "Bug Buggson"
                                                
                                            }
                                    }

                        }
                });



            return View(model);
        }

    }
}