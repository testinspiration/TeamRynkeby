﻿using EventBooking.Data;
using WebMatrix.WebData;

namespace EventBooking.Services
{
    public interface ISecurityService
    {
        bool IsLoggedIn { get; }
        User GetUser(string userName);
        void SignOff();
        bool SignIn(string username, string password);
    }

    public class SecurityService : ISecurityService
    {
        public virtual User GetUser(string userName)
        {
            int userId = WebSecurity.GetUserId(userName);
            using (var context = new EventBookingContext())
            {
                return context.Users.Find(userId);
            }
        }

        public virtual bool SignIn(string userName, string password)
        {
            return WebSecurity.Login(userName, password);
        }

        public void SignOff()
        {
            WebSecurity.Logout();
        }

        public virtual bool IsLoggedIn
        {
            get { return WebSecurity.IsAuthenticated; }
        }
    }

    public class MockupSecurityService : SecurityService
    {
        private bool _isLoggedin;

        public string AcceptedEmail { get; set; }

        public string AcceptedPassword { get; set; }

        public override bool IsLoggedIn
        {
            get { return _isLoggedin; }
        }
        public override bool SignIn(string userName, string password)
        {
            if (userName == AcceptedEmail && password == AcceptedPassword)
            {
                _isLoggedin = true;
                return true;
            }
            return false;
        }

        public override User GetUser(string userName)
        {
            if (userName == AcceptedEmail)
            {
                _isLoggedin = true;
                return new User();
            }
            return null;
        }
    }
}