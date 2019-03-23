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
            throw new NotImplementedException();
        }

        public List<PrivateDiscussionBoard> GetAll()
        {
            return db.PrivateDiscussionBoards.ToList();
        }

        public PrivateDiscussionBoard GetByID(string id)
        {
            throw new NotImplementedException();
        }

        public PrivateDiscussionBoard Put(PrivateDiscussionBoard item)
        {
           return db.PrivateDiscussionBoards.Add(item);
        }
    }
}