using EduComBoards.BusinessModel;
using EduComBoards.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduComBoards.DAL;
using DataClasses;

namespace EduComBoards.DAL
{
    public class User : IAppUser<ApplicationUser>
    {
        ApplicationDbContext appDbContext = new ApplicationDbContext();
        BusinessModelDBContext bussinessDbContext = new BusinessModelDBContext();

        public List<ApplicationUser> GetAll()
        {
            return appDbContext.Users.ToList();
        }

        public ApplicationUser GetByID(string id)
        {
            throw new NotImplementedException();
        }

        //public ApplicationUser GetByID(string id)
        //{
        //    return appDbContext.Users.Select(s => s.Id == id);
        //}

        public ApplicationUser Put(ApplicationUser item)
        {
            throw new NotImplementedException();
        }
    }
}