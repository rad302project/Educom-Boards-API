using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduComBoards.DAL.PrivateDiscussionBoards
{
    interface IPrivateDiscussion<PrivateDiscussionBoard>
    {
        List<PrivateDiscussionBoard> GetAll();
        PrivateDiscussionBoard GetByID(string id);
        PrivateDiscussionBoard Put(PrivateDiscussionBoard item);
    }
}
