﻿using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EventBooking.Data
{
    public class EventBookingContext : DbContext, IEventBookingContext
    {
        public EventBookingContext()
            : base("DefaultConnection")
        {
        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Activity> Activities { get; set; }
        public IDbSet<Team> Teams { get; set; }

        void IEventBookingContext.SaveChanges()
        {
            this.SaveChanges();
        }

        DbEntityEntry IEventBookingContext.Entry<TEntity>(TEntity entity)
        {
            return this.Entry(entity);
        }
    }
}