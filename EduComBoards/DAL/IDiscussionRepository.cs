using DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduComBoards.DAL
{
    public interface IDiscussionRepository : IDiscussion<DiscussionBoard>, IDisposable
    {

    }
}
