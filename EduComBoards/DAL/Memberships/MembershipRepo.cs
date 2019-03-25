using EduComBoards.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduComBoards.DAL.Memberships
{
    public class MembershipRepo : Memberships<PrivateDiscussionBoardMemberships>
    {
        private BusinessModelDBContext db = new BusinessModelDBContext();
        public PrivateDiscussionBoardMemberships addMembership(PrivateDiscussionBoardMemberships membership)
        {
           db.Memberships.Add(membership);
            db.SaveChanges();
            return membership;
        }

        public List<PrivateDiscussionBoardMemberships> GetAll()
        {
            return db.Memberships.ToList();
        }

        public List<PrivateDiscussionBoardMemberships> getByBoardID(int id)
        {
            var memberships = (from membershipss in db.Memberships
                                            where membershipss.BoardID == id
                                            select membershipss);

            return memberships.ToList();
        }

        public PrivateDiscussionBoardMemberships deleteMembership(PrivateDiscussionBoardMemberships membership)
        {
            return db.Memberships.Remove(membership);
        }

        public PrivateDiscussionBoardMemberships Put(int id, PrivateDiscussionBoardMemberships membership)
        {
            throw new NotImplementedException();
        }

        public PrivateDiscussionBoardMemberships GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}