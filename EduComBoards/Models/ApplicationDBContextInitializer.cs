using EduComBoards.BusinessModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace EduComBoards.Models
{
    public class ApplicationDBContextInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        public ApplicationDBContextInitializer()
        {

        }
        protected override void Seed(ApplicationDbContext context)
        {
            BusinessModelDBContext db = new BusinessModelDBContext();
            Random r = new Random();
            PasswordHasher hasher = new PasswordHasher();
            context.Users.AddOrUpdate(new ApplicationUser
            {
                UserName = "admin@admin.ie",
                Email = "admin@admin.ie",
                EmailConfirmed = true,
                FirstName = "admin",
                SecondName = "admin",
                PasswordHash = hasher.HashPassword("admin$1"),
                SecurityStamp = Guid.NewGuid().ToString()
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}