using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FenBaoApiTest.Models;
using Microsoft.EntityFrameworkCore;

namespace FenBaoApiTest.DataBase
{
    public class AppDbcontext:DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options):base(options)
        {

        }
        public DbSet<Activity> activities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>().HasData(new Activity()
            {
                Id = Guid.NewGuid(),
                Name = "1",
                ActivityScore = 2.0M,
                Comment = "",
                ParticipantsNum = 2,
                ActivityTime = DateTime.Now,
                ActivtyAddress = "博文楼",
                ActivtyStatus = true
            }
            ) ;
            base.OnModelCreating(modelBuilder);
        }
    }
}
