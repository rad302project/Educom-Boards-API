using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataClasses;

namespace EduComBoards.BusinessModel
{
    public class BusinessModelDBContext : DbContext
    {
        public BusinessModelDBContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new BusinessModelDBInitializer());
            Database.Initialize(true);
            Configuration.LazyLoadingEnabled = false;
        }

        #region DbSets
        public DbSet<Member> Members { get; set; }
        public DbSet<DiscussionBoard> DiscussionBoards { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<PrivateDiscussionBoard> PrivateDiscussionBoards { get; set; }
        public DbSet<PrivatePost> PrivatePosts { get; set; }
        #endregion

    }
}
