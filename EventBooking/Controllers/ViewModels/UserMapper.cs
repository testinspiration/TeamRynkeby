﻿using AutoMapper;
using EventBooking.Data;

namespace EventBooking.Controllers.ViewModels
{
    public class UserMapper
    {
        public static User MapUserTemp(User destination, User source)
        {
            destination.Birthdate = source.Birthdate;
            destination.Cellphone = source.Cellphone;
            destination.City = source.City;
            destination.Created = source.Created;
            destination.Name = source.Name;
            destination.StreetAddress = source.StreetAddress;
            destination.Zipcode = source.Zipcode;
            destination.Team = source.Team;

            return destination;
        }
    }
}