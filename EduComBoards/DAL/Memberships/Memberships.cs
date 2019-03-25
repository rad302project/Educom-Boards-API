using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduComBoards.Models;
namespace EduComBoards.DAL.Memberships
{
    interface Memberships<PrivateDiscussionBoardMemberships>
    {
        List<PrivateDiscussionBoardMemberships> GetAll();
        PrivateDiscussionBoardMemberships GetByID(int id);
        PrivateDiscussionBoardMemberships Put(int id, PrivateDiscussionBoardMemberships membership);
        List<PrivateDiscussionBoardMemberships> getByBoardID(int id);
        PrivateDiscussionBoardMemberships addMembership(PrivateDiscussionBoardMemberships membership);
    }
}
