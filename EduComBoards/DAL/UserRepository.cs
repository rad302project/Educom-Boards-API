using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduComBoards.Models;

namespace EduComBoards.DAL
{
    public class UserRepository : IUser
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public List<ApplicationUser> getAll()
        {
            return db.Users.ToList();
        }

        public ApplicationUser getById(int id)
        {
            return db.Users.Find(id);
        }

        public ApplicationUser getByName(string name)
        {
            return db.Users.Where(u => u.FirstName == name).FirstOrDefault();
        }
    }
}