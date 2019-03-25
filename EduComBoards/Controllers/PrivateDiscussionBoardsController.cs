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
using EduComBoards.DAL.PrivateDiscussionBoards;

namespace EduComBoards.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/PrivateDiscussionBoards")]
    public class PrivateDiscussionBoardsController : ApiController
    {
        private BusinessModelDBContext db = new BusinessModelDBContext();

        public IPrivateDiscussion<PrivateDiscussionBoard> repository;

        public PrivateDiscussionBoardsController(IPrivateDiscussion<PrivateDiscussionBoard> repo)
        {
            this.repository = repo;
        }
        public PrivateDiscussionBoardsController()
        {
            repository = new IPrivateDiscussionRepo();
        }


        // GET: api/DiscussionBoards
        // Leaving this here for later when auth added
        // Only "members" can see all discussions 
        // but any logged in user should be assigned role of member
        //[Authorize(Roles = "Member")]
        [Route("getAllPrivateDiscussions")]
        public List<PrivateDiscussionBoard> GetAllPrivateDiscussionBoards()
        {
            return repository.GetAll();
        }

        public BusinessModelDBContext Db { get => db; set => db = value; }

        // GET: api/PrivateDiscussionBoards/5
        [ResponseType(typeof(PrivateDiscussionBoard))]
        public async Task<IHttpActionResult> GetPrivateDiscussionBoard(int id)
        {
            PrivateDiscussionBoard privateDiscussionBoard = repository.GetByID(id);
            return Ok(privateDiscussionBoard);
        }


        // PUT: api/PrivateDiscussionBoards/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPrivateDiscussionBoard(int id, PrivateDiscussionBoard privateDiscussionBoard)
        {
            repository.PutPrivateDiscussionBoard(id, privateDiscussionBoard);

            return StatusCode(HttpStatusCode.NoContent);
        }
        [HttpPost]
        [Route("postDiscussion")]
        [ResponseType(typeof(PrivateDiscussionBoard))]
        public async Task<IHttpActionResult> PostPrivateDiscussionBoard(PrivateDiscussionBoard privateDiscussionBoard)
        {
            repository.PostPrivateDiscussionBoard(privateDiscussionBoard);
            return Content(HttpStatusCode.OK, privateDiscussionBoard);

        }

        // DELETE: api/PrivateDiscussionBoards/5
        [ResponseType(typeof(PrivateDiscussionBoard))]
        public async Task<IHttpActionResult> DeletePrivateDiscussionBoard(int id)
        {
          repository.DeletePrivateDiscussionBoard(id);
            return Ok();
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
            return repository.PrivateDiscussionBoardExists(id);
        }
    }
}