using FenBaoApiTest.DataBase;
using FenBaoApiTest.Models;
using Microsoft.EntityFrameworkCore;
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

        public bool ActivityExists(Guid ActivityRouteId)
        {
            return _context.activities.Any(a => a.Id == ActivityRouteId);
        }

        public void AddActivity(Activity activity)
        {
            if (activity == null)
            {
                throw new ArgumentNullException(nameof(activity));
            }
            _context.activities.Add(activity);

        }

        public void AddComment(Guid ActivityId, Comment comment)
        {
            if (ActivityId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(ActivityId));
            }
            if (comment == null)
            {
                throw new ArgumentNullException(nameof(comment));
            }
            comment.ActivityId = ActivityId;
            _context.comments.Add(comment);
        }

        public void DeleteActivity(Activity activity)
        {
            _context.activities.Remove(activity);
        }

        public void DeleteComment(Comment comment)
        {
            _context.comments.Remove(comment);
        }

        public IEnumerable<Activity> GetActivities(string keyword)
        {
            IQueryable<Activity> result = _context.activities.Include(a => a.Comments);
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                result = result.Where(a => a.Name.Contains(keyword));
            }
            return result.ToList();
        }

        public Activity GetActivity(Guid ActivityId)
        {
            return _context.activities.Include(a => a.Comments).FirstOrDefault(n => n.Id == ActivityId);
        }

        public Comment GetComment(int CommentId)
        {
            return _context.comments.Where(c => c.Id == CommentId).FirstOrDefault();
        }

        public IEnumerable<Comment> GetCommentByActivityId(Guid ActivityRouteId)
        {
            return _context.comments.Where(c => c.ActivityId == ActivityRouteId).ToList();
        }

        public bool Save()
        {
            return (_context.SaveChanges()>=0);
        }

      

    }
}
