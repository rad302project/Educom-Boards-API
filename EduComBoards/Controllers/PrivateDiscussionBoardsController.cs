using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using EduComBoards.BusinessModel;

namespace EduComBoards.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/PrivateDiscussionBoards")]
    public class PrivateDiscussionBoardsController : ApiController
    {
        
        private BusinessModelDBContext db = new BusinessModelDBContext();

        public BusinessModelDBContext Db { get => db; set => db = value; }

        // GET: api/PrivateDiscussionBoards
        public IQueryable<PrivateDiscussionBoard> GetDiscussionBoards()
        {
            return Db.PrivateDiscussionBoards;
        }

        // GET: api/PrivateDiscussionBoards/5
        [ResponseType(typeof(PrivateDiscussionBoard))]
        public async Task<IHttpActionResult> GetPrivateDiscussionBoard(int id)
        {
            PrivateDiscussionBoard privateDiscussionBoard = await Db.PrivateDiscussionBoards.FindAsync(id);
            if (privateDiscussionBoard == null)
            {
                return NotFound();
            }

            return Ok(privateDiscussionBoard);
        }

        // PUT: api/PrivateDiscussionBoards/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPrivateDiscussionBoard(int id, PrivateDiscussionBoard privateDiscussionBoard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != privateDiscussionBoard.ID)
            {
                return BadRequest();
            }

            Db.Entry(privateDiscussionBoard).State = EntityState.Modified;

            try
            {
                await Db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrivateDiscussionBoardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PrivateDiscussionBoards
        [ResponseType(typeof(PrivateDiscussionBoard))]
        public async Task<IHttpActionResult> PostPrivateDiscussionBoard(PrivateDiscussionBoard privateDiscussionBoard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Db.PrivateDiscussionBoards.Add(privateDiscussionBoard);
            await Db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = privateDiscussionBoard.ID }, privateDiscussionBoard);
        }

        // DELETE: api/PrivateDiscussionBoards/5
        [ResponseType(typeof(PrivateDiscussionBoard))]
        public async Task<IHttpActionResult> DeletePrivateDiscussionBoard(int id)
        {
            PrivateDiscussionBoard privateDiscussionBoard = await Db.PrivateDiscussionBoards.FindAsync(id);
            if (privateDiscussionBoard == null)
            {
                return NotFound();
            }

            Db.PrivateDiscussionBoards.Remove(privateDiscussionBoard);
            await Db.SaveChangesAsync();

            return Ok(privateDiscussionBoard);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrivateDiscussionBoardExists(int id)
        {
            return Db.DiscussionBoards.Count(e => e.ID == id) > 0;
        }
    }
}