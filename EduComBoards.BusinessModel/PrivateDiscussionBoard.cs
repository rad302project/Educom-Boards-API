using DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduComBoards.BusinessModel
{
   public class PrivateDiscussionBoard: DiscussionBoard 
    {
        public Member[] members { get; set; }
    }
}
