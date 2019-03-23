using EduComBoards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduComBoards.DAL
{
    interface IUser
    {
        ApplicationUser getById(string id);
        ApplicationUser getByName(string name);
        List<ApplicationUser> getAll();
    }
}
