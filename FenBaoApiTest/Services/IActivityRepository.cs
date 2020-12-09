using FenBaoApiTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FenBaoApiTest.Services
{
   public interface IActivityRepository
    {
        IEnumerable<Activity> GetActivities();

        Activity GetActivity(Guid ActivityId);
    }
}
