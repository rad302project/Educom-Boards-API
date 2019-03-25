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
        PrivateDiscussionBoard PostPrivateDiscussionBoard(PrivateDiscussionBoard privateDiscussionBoard);
        void DeletePrivateDiscussionBoard(int id);
        bool PrivateDiscussionBoardExists(int id);
        void PutPrivateDiscussionBoard(int id, PrivateDiscussionBoard privateDiscussionBoard);
    }
}
