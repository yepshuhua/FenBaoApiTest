using FenBaoApiTest.DataBase;
using FenBaoApiTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FenBaoApiTest.Services
{
    public class ActivityRepository:IActivityRepository
    {
        private readonly AppDbcontext _context;
        public ActivityRepository(AppDbcontext context)
        {
            _context = context;
        }
        public IEnumerable<Activity> GetActivities()
        {
            return _context.activities;
        }

        public Activity GetActivity(Guid ActivityId)
        {
            return _context.activities.FirstOrDefault(n => n.Id == ActivityId);
        }
    }
}
