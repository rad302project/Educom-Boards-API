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
        public DbSet<DiscussionBoard> DiscussionBoards { get; set; }

        public BusinessModelDBContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new BusinessModelDBInitializer());
            Database.Initialize(true);
        }
    }
}
