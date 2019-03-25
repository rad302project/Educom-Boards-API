using EduComBoards.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduComBoards.DAL
{
    interface IPost
    {
        List<Post> getAllPublic();
        List<PrivatePost> getAllPrivate();
        Post CreatePublic(Post post);
        PrivatePost CreatePrivate(PrivatePost post);
        Post getPostById(int id);
        PrivatePost getPrivatePostById(int id);
        Post Put(Post post);
        Post PutPrivate(Post post);
        List<Post> getPublicPostsByBoardId(int id);
        List<PrivatePost> getPrivatePostsByBoardId(int id);
        void DeletePrivatePost(int id);
        void DeletePublicPost(int id);
    }
}
