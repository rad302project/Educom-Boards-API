using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduComBoards.DAL.PrivateDiscussionBoards
{
   public interface IPrivateDiscussion<PrivateDiscussionBoard>
    {
        List<PrivateDiscussionBoard> GetAll();
        PrivateDiscussionBoard GetByID(int id);
        PrivateDiscussionBoard Put(PrivateDiscussionBoard item);
    }
}
