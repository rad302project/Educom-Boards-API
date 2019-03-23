using EduComBoards.BusinessModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // seeding/creating roles
            context.Roles.AddOrUpdate(new IdentityRole { Name = "Admin" });
            context.Roles.AddOrUpdate(new IdentityRole { Name = "Moderator" });
            context.Roles.AddOrUpdate(new IdentityRole { Name = "Contributor" });
            context.Roles.AddOrUpdate(new IdentityRole { Name = "Member" });
            context.Roles.AddOrUpdate(new IdentityRole { Name = "Lecturer" });
            context.Roles.AddOrUpdate(new IdentityRole { Name = "Student" });

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
            ApplicationUser admin = manager.FindByEmail("admin@admin.ie");
            if (admin != null)
            {
                manager.AddToRoles(admin.Id, new string[] { "Admin" });
            }

            seedTestUsers(context, manager);
            context.SaveChanges();
            base.Seed(context);
        }

        // We're seeding a few test users to test authentication and roles
        public static void seedTestUsers(ApplicationDbContext context, UserManager<ApplicationUser> manager)
        {
            PasswordHasher hasher = new PasswordHasher();
            context.Users.AddOrUpdate(new ApplicationUser
            {
                UserName = "mod@mod.ie",
                Email = "mod@mod.ie",
                EmailConfirmed = true,
                FirstName = "mod",
                SecondName = "mod",
                PasswordHash = hasher.HashPassword("mod$1"),
                SecurityStamp = Guid.NewGuid().ToString()
            });
            context.Users.AddOrUpdate(new ApplicationUser
            {
                UserName = "contributor@contributor.ie",
                Email = "contributor@contributor.ie",
                EmailConfirmed = true,
                FirstName = "contributor",
                SecondName = "contributor",
                PasswordHash = hasher.HashPassword("contributor$1"),
                SecurityStamp = Guid.NewGuid().ToString()
            });
            context.Users.AddOrUpdate(new ApplicationUser
            {
                UserName = "member@member.ie",
                Email = "member@member.ie",
                EmailConfirmed = true,
                FirstName = "member",
                SecondName = "member",
                PasswordHash = hasher.HashPassword("member$1"),
                SecurityStamp = Guid.NewGuid().ToString()
            });
            context.SaveChanges();

            ApplicationUser contributor = manager.FindByEmail("contributor@contributor.ie");
            if (contributor != null)
            {
                manager.AddToRoles(contributor.Id, new string[] { "Contributor" });
            }
            ApplicationUser Moderator = manager.FindByEmail("mod@mod.ie");
            if (Moderator != null)
            {
                manager.AddToRoles(Moderator.Id, new string[] { "Moderator" });
            }
            ApplicationUser member = manager.FindByEmail("member@member.ie");
            if (member != null)
            {
                manager.AddToRoles(member.Id, new string[] { "Member", "Lecturer" });
            }
        }
    }
}