using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduComBoards.DAL.Post
{
     public interface IPost<Post>
    {
        List<Post> GetAll();
        Post GetByID(int id);
        Post Put(Post item);
    }
}
