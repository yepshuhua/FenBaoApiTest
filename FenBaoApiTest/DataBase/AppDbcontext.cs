using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FenBaoApiTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FenBaoApiTest.DataBase
{
    public class AppDbcontext:IdentityDbContext<AppcationUser>
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options):base(options)
        {

        }
        public DbSet<Activity> activities { get; set; }
        public DbSet<Comment> comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>().HasData(new Activity()
            {
                Id = Guid.NewGuid(),
                Name = "1",
                ActivityScore = 2.0M,
                ParticipantsNum = 2,
                ActivityTime = DateTime.Now,
                ActivtyAddress = "博文楼",
                ActivtyStatus = true
            }
          );
            modelBuilder.Entity<AppcationUser>(u => u.HasMany(x => x.UserRoles).WithOne().HasForeignKey(ur => ur.UserId).IsRequired());
            var adminRoleId = "";
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                });
            //添加用户
            var adminUserId = "";
            AppcationUser adminUser = new AppcationUser
            {
                Id = adminUserId,
                UserName = "123",
                NormalizedUserName = "123".ToUpper(),
                Email = "123@qq.com",
                NormalizedEmail = "123@qq.com",
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                PhoneNumber = "1231241244",
                PhoneNumberConfirmed = false
            };
            var ph = new PasswordHasher<AppcationUser>();
            adminUser.PasswordHash = ph.HashPassword(adminUser, "123@Abc");
            modelBuilder.Entity<AppcationUser>().HasData(adminUser);
            //加入管理员角色
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = adminRoleId,
                    UserId = adminUserId
                };
            base.OnModelCreating(modelBuilder);
        }
    }
}
