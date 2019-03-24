﻿using DataClasses;
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

        public DiscussionBoard GetByID(string id)
        {
            throw new NotImplementedException();
        }

        public DiscussionBoard Put(DiscussionBoard item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}