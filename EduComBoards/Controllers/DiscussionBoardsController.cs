using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using DataClasses;
using EduComBoards.BusinessModel;
using EduComBoards.DAL;
using EduComBoards.Models;
using EduComBoards.Helpers;

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
        [Authorize(Roles = "Admin, Moderator, Contributor, Member")]
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
        [Authorize(Roles = "Admin, Moderator, Contributor, Member")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchDiscussionBoards(string searchTerm)
        {
            List<DiscussionBoard> discussionBoards = repository.SearchBoards(searchTerm);
            if (discussionBoards == null)
            {
                return NotFound();
            }
            var users = from post in db.Posts
                        join member in db.Members
                        on post.MemberID equals member.MemberID
                        select member.MemberID;
            //var emails = db.
            //SendEmail("jammydodger8910@gmail.com", "James");
            return Ok(discussionBoards);
        }

        // GET: api/DiscussionBoards/5
        [ResponseType(typeof(DiscussionBoard))]
        [Authorize(Roles = "Admin, Moderator, Contributor")]
        public IHttpActionResult GetDiscussionBoard(int id)
        {
           DiscussionBoard discussion = repository.GetByID(id);
            return Ok(discussion);
        }

        // PUT: api/DiscussionBoards/5
        [Authorize(Roles = "Admin, Moderator, Contributor")]
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
        [Authorize(Roles = "Admin, Moderator, Contributor")]
        [ResponseType(typeof(DiscussionBoard))]
        public IHttpActionResult PostDiscussionBoard(DiscussionBoard discussionBoard)
        {
            repository.Create(discussionBoard);
            return Content(HttpStatusCode.OK, discussionBoard);
        }

        // DELETE: api/DiscussionBoards/5
        [Authorize(Roles = "Admin, Moderator, Contributor")]
        [ResponseType(typeof(DiscussionBoard))]
        public IHttpActionResult DeleteDiscussionBoard(int id)
        {
            repository.Delete(id);
            return Ok("deleting");
        }

        public void SendEmail(string recipentAddress, string recipientName)
        {
            EmailHelper emailHelper = new EmailHelper();
            emailHelper.SendEmail(recipentAddress, recipientName);
        }

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
        }

        private bool DiscussionBoardExists(int id)
        {
            return db.DiscussionBoards.Count(e => e.ID == id) > 0;
        }
    }
}