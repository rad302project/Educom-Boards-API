using DataClasses;
using EduComBoards.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduComBoards.DAL
{
    public class DiscussionRepo : IDiscussionRepository
    {
        public BusinessModelDBContext db = new BusinessModelDBContext();

        public IEnumerable<DiscussionBoard> GetAll()
        {
            return db.DiscussionBoards.ToList();
        }

        public DiscussionBoard Put(DiscussionBoard item)
        {
            throw new NotImplementedException();
        }
        public DiscussionBoard Create(DiscussionBoard discussionBoard)
        {
            db.DiscussionBoards.Add(new DiscussionBoard
            {
                ID = discussionBoard.ID,
                Title = discussionBoard.Title,
                Content = discussionBoard.Content,
                CreatedAt = DateTime.Now,
                MemberID = 1
            });
            db.SaveChanges();
            return discussionBoard;
        }
        public void Dispose()
        {
            db.Dispose();
        }

        public DiscussionBoard GetByID(int id)
        {
            DiscussionBoard discussion = db.DiscussionBoards.Find(id);
            return discussion;
        }

        public void Delete(int id)
        {
            DiscussionBoard board = db.DiscussionBoards.Where(d => d.ID == id).SingleOrDefault();
            db.DiscussionBoards.Remove(board);
            db.SaveChanges();
        }
    }
}