using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduComBoards.BusinessModel;
namespace EduComBoards.DAL.Post
{
   public interface IPostRepository: IPost<EduComBoards.BusinessModel.Post>, IDisposable
    {
    }
}
