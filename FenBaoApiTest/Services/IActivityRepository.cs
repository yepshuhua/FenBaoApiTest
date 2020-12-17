using FenBaoApiTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FenBaoApiTest.Services
{
   public interface IActivityRepository
    {
        IEnumerable<Activity> GetActivities( string keyword);

        Activity GetActivity(Guid ActivityRouteId);

        bool ActivityExists(Guid ActivityRouteId);

        IEnumerable<Comment> GetCommentByActivityId(Guid ActivityRouteId);

        Comment GetComment(int CommentId);
        void AddActivity(Activity activity);
        void AddComment(Guid ActivityId, Comment comment);
        bool Save();
    }
}
