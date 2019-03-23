using DataClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduComBoards.BusinessModel
{
    class BusinessModelDBInitializer : DropCreateDatabaseIfModelChanges<BusinessModelDBContext>
    {
        public BusinessModelDBInitializer()
        {

        }
        protected override void Seed(BusinessModelDBContext context)
        {
            List<DiscussionBoard> discussions = new List<DiscussionBoard>();
            for (int i = 0; i < 3; i++)
            {
                discussions.Add(new DiscussionBoard
                {
                    Title = "Test",
                    CreatedAt = DateTime.Parse("10/10/2010")
                });
            }
            context.DiscussionBoards.AddRange(discussions);
            context.SaveChanges();
        }
    }
}
