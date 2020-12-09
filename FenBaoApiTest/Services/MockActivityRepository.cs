using FenBaoApiTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FenBaoApiTest.Services
{
    public class MockActivityRepository : IActivityRepository
    {
        private List<Activity> _activities;
        public MockActivityRepository()
        {
            if (_activities == null)
            {
                InitializeActivity();
            }
        }
        private void InitializeActivity()
        {
            _activities = new List<Activity>()
            {
                new Activity
                {
                     Id=new Guid(),
                     Name="1",
                     ActivityScore=2.0M,
                     Comment="",
                     ParticipantsNum=2,
                     ActivityTime=DateTime.Now,
                     ActivtyAddress="博文楼",
                     ActivtyStatus=true
                },
                 new Activity
                {
                     Id=new Guid(),
                     Name="2",
                     ActivityScore=1.0M,
                     Comment="",
                     ParticipantsNum=2,
                     ActivityTime=DateTime.Now,
                     ActivtyAddress="静则楼",
                     ActivtyStatus=true
                }
            };
        }
        public IEnumerable<Activity> GetActivities()
        {
            return _activities;
        }

        public Activity GetActivity(Guid ActivityId)
        {
            return _activities.FirstOrDefault(x => x.Id == ActivityId);
        }
    }
}
