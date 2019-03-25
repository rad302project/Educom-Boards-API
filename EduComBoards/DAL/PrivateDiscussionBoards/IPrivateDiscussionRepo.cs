using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduComBoards.BusinessModel;

namespace EduComBoards.DAL.PrivateDiscussionBoards
{
    public class IPrivateDiscussionRepo : IPrivateDiscussionRepository
    {
        public BusinessModelDBContext db = new BusinessModelDBContext();

        public void Dispose()
        {
            db.Dispose();
        }

        public List<PrivateDiscussionBoard> GetAll()
        {
            return db.PrivateDiscussionBoards.ToList();
        }

     
        public PrivateDiscussionBoard GetByID(int id)
        {
            PrivateDiscussionBoard board = (from boards in db.PrivateDiscussionBoards
                                            where boards.ID == id
                                            select boards).FirstOrDefault();

            return board;
        }

        public PrivateDiscussionBoard Put(PrivateDiscussionBoard item)
        {
           return db.PrivateDiscussionBoards.Add(item);
        }
    }
}