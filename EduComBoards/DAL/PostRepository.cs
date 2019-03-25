using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduComBoards.BusinessModel;

namespace EduComBoards.DAL
{
    public class PostRepository : IPost, IDisposable
    {
        BusinessModelDBContext db = new BusinessModelDBContext();
        
        public Post Create(Post post)
        {
            db.Posts.Add(new Post
            {
                Title = post.Title,
                Content = post.Content,
                MemberID = post.MemberID,
                boardId = post.boardId
            });
            db.SaveChanges();
            return post;
        }

        public PrivatePost CreatePrivate(PrivatePost post)
        {
            db.PrivatePosts.Add(new PrivatePost
            {
                Title = post.Title,
                Content = post.Content,
                MemberID = post.MemberID,
                BoardID = post.BoardID
            });
            db.SaveChanges();
            return post;
        }

        public Post CreatePublic(Post post)
        {
            db.Posts.Add(new Post
            {
                Title = post.Title,
                Content = post.Content,
                MemberID = post.MemberID,
                boardId = post.boardId
            });
            db.SaveChanges();
            return post;
        }

        public void DeletePublicPost(int id)
        {
            Post post = db.Posts.Where(d => d.ID == id).SingleOrDefault();
            db.Posts.Remove(post);
            db.SaveChanges();
        }
        public void DeletePrivatePost(int id)
        {
            PrivatePost post = db.PrivatePosts.Where(d => d.ID == id).SingleOrDefault();
            db.PrivatePosts.Remove(post);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public List<Post> getAllPublic()
        {
            return db.Posts.ToList();
        }
        public List<PrivatePost> getAllPrivate()
        {
            return db.PrivatePosts.ToList();
        }

        public Post getPostById(int id)
        {
            Post post = db.Posts.Find(id);
            return post;
        }
        public PrivatePost getPrivatePostById(int id)
        {
            PrivatePost post = db.PrivatePosts.Find(id);
            return post;
        }

        public List<PrivatePost> getPrivatePostsByBoardId(int id)
        {
            List<PrivatePost> privatePosts = db.PrivatePosts.Where(s => s.BoardID.Equals(id)).ToList();
            return privatePosts;
        }
        public List<Post> getPublicPostsByBoardId(int id)
        {
            List<Post> posts = db.Posts.Where(s => s.boardId.Equals(id)).ToList();
            return posts;
        }

        public Post Put(Post post)
        {
            throw new NotImplementedException();
        }

        public Post PutPrivate(Post post)
        {
            throw new NotImplementedException();
        }
    }
}