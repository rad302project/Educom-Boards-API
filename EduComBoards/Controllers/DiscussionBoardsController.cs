using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using DataClasses;
using EduComBoards.BusinessModel;
using EduComBoards.DAL;
using EduComBoards.Models;

namespace EduComBoards.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/DiscussionBoards")]
    public class DiscussionBoardsController : ApiController
    {
        private BusinessModelDBContext db = new BusinessModelDBContext();

        public IDiscussionRepository repository;

        public DiscussionBoardsController(IDiscussionRepository repo)
        {
            this.repository = repo;
        }
        public DiscussionBoardsController()
        {
            repository = new DiscussionRepo();
        }


        // GET: api/DiscussionBoards
        // Leaving this here for later when auth added
        // Only "members" can see all discussions 
        // but any logged in user should be assigned role of member
        //[Authorize(Roles = "Member")]
        [Route("getDiscussions")]
        public IEnumerable<DiscussionBoard> GetDiscussionBoards()
        {
            var discussions = from d in repository.GetAll()
                              select d;

            return discussions;
        }
        
        //GET: api/DiscussionBoards/getDiscussions/Test
        [ResponseType(typeof(List<DiscussionBoard>))]
        [HttpGet]
        [Route("getDiscussions/{searchTerm}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchDiscussionBoards(string searchTerm)
        {
            List<DiscussionBoard> discussionBoards = db.DiscussionBoards.Where(s => s.Title.Contains(searchTerm)).ToList();
            if (discussionBoards == null)
            {
                return NotFound();
            }

            return Ok(discussionBoards);
        }
        
        // GET: api/DiscussionBoards/5
        [ResponseType(typeof(DiscussionBoard))]
        public IHttpActionResult GetDiscussionBoard(int id)
        {
            DiscussionBoard discussionBoard = db.DiscussionBoards.Find(id);
            if (discussionBoard == null)
            {
                return NotFound();
            }

            return Ok(discussionBoard);
        }
        
        // PUT: api/DiscussionBoards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDiscussionBoard(int id, DiscussionBoard discussionBoard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != discussionBoard.ID)
            {
                return BadRequest();
            }

            db.Entry(discussionBoard).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscussionBoardExists(id))
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

        // POST: api/DiscussionBoards
        [HttpPost]
        [Route("postDiscussion")]
        [ResponseType(typeof(DiscussionBoard))]
        public IHttpActionResult PostDiscussionBoard(DiscussionBoard discussionBoard)
        {
            using (BusinessModelDBContext db = new BusinessModelDBContext())
            {
                db.DiscussionBoards.Add(new DiscussionBoard
                {
                    ID = discussionBoard.ID,
                    Title = discussionBoard.Title,
                    CreatedAt = DateTime.Now
                });
                db.SaveChanges();
                return Content(HttpStatusCode.OK, discussionBoard);
            }
        }

        // DELETE: api/DiscussionBoards/5
        [ResponseType(typeof(DiscussionBoard))]
        public IHttpActionResult DeleteDiscussionBoard(int id)
        {
            DiscussionBoard discussionBoard = db.DiscussionBoards.Find(id);
            if (discussionBoard == null)
            {
                return NotFound();
            }

            db.DiscussionBoards.Remove(discussionBoard);
            db.SaveChanges();

            return Ok(discussionBoard);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DiscussionBoardExists(int id)
        {
            return db.DiscussionBoards.Count(e => e.ID == id) > 0;
        }
    }
}