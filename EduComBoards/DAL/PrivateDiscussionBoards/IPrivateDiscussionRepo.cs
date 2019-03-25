using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using EduComBoards.BusinessModel;

namespace EduComBoards.DAL.PrivateDiscussionBoards
{
    public class IPrivateDiscussionRepo : IPrivateDiscussion<PrivateDiscussionBoard>
    {
        private BusinessModelDBContext db = new BusinessModelDBContext();
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
       

        public PrivateDiscussionBoard PostPrivateDiscussionBoard(PrivateDiscussionBoard privateDiscussionBoard)
        {

            db.PrivateDiscussionBoards.Add(new PrivateDiscussionBoard
            {
                Title = privateDiscussionBoard.Title,
                CreatedAt = DateTime.Now,
                Content = privateDiscussionBoard.Content
            });
            db.SaveChanges();
            return privateDiscussionBoard;

        }

        public async void DeletePrivateDiscussionBoard(int id)
        {
            PrivateDiscussionBoard privateDiscussionBoard = await db.PrivateDiscussionBoards.FindAsync(id);
            db.PrivateDiscussionBoards.Remove(privateDiscussionBoard);
            await db.SaveChangesAsync();
        }

        public bool PrivateDiscussionBoardExists(int id)
        {
            return db.DiscussionBoards.Count(e => e.ID == id) > 0;
        }

        public async void PutPrivateDiscussionBoard(int id, PrivateDiscussionBoard privateDiscussionBoard)
        {
            db.Entry(privateDiscussionBoard).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrivateDiscussionBoardExists(id))
                {

                }
                else
                {
                    throw;
                }
            }


        }

   
    }
}