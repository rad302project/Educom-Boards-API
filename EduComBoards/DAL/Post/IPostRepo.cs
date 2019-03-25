using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduComBoards.BusinessModel;

namespace EduComBoards.DAL.Post
{
    public class IPostRepo : IPostRepository
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<EduComBoards.BusinessModel.Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public EduComBoards.BusinessModel.Post GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public EduComBoards.BusinessModel.Post Put(EduComBoards.BusinessModel.Post item)
        {
            throw new NotImplementedException();
        }


        List<BusinessModel.Post> IPost<BusinessModel.Post>.GetAll()
        {
            throw new NotImplementedException();
        }

        BusinessModel.Post IPost<BusinessModel.Post>.GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}