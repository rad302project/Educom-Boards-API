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
using EduComBoards.DAL.Memberships;

namespace EduComBoards.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/Memberships")]
    public class MembershipsController : ApiController
    {
        private BusinessModelDBContext db = new BusinessModelDBContext();

        public MembershipRepo repository;

        public MembershipsController(MembershipRepo repo)
        {
            this.repository = repo;
        }
        public MembershipsController()
        {
            repository = new MembershipRepo();
        }
        // GET: api/Memberships
        public List<PrivateDiscussionBoardMemberships> GetMemberships()
        {
            return repository.GetAll();
        }

        // GET: api/Memberships/5
        [ResponseType(typeof(PrivateDiscussionBoardMemberships))]
        public PrivateDiscussionBoardMemberships GetPrivateDiscussionBoardMemberships(int id)
        {
            return repository.GetByID(id);
        }

        // PUT: api/Memberships/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPrivateDiscussionBoardMemberships(int id, PrivateDiscussionBoardMemberships privateDiscussionBoardMemberships)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != privateDiscussionBoardMemberships.ID)
            {
                return BadRequest();
            }

            db.Entry(privateDiscussionBoardMemberships).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrivateDiscussionBoardMembershipsExists(id))
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


        [HttpPost]
        [Route("addMembership")]
        [ResponseType(typeof(PrivateDiscussionBoardMemberships))]
        public IHttpActionResult AddPostToPrivateDiscussionBoard(PrivateDiscussionBoardMemberships membership)
        {
            db.Memberships.Add(membership);
            repository.addMembership(membership);
            return Content(HttpStatusCode.OK, membership);
        }

        // DELETE: api/Memberships/5
        [ResponseType(typeof(PrivateDiscussionBoardMemberships))]
        public PrivateDiscussionBoardMemberships DeletePrivateDiscussionBoardMemberships(PrivateDiscussionBoardMemberships membership)
        {
            return repository.deleteMembership(membership);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrivateDiscussionBoardMembershipsExists(int id)
        {
            return db.Memberships.Count(e => e.ID == id) > 0;
        }
    }
}