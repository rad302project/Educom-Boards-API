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
using EduComBoards.BusinessModel;
using EduComBoards.DAL;
using EduComBoards.Models;
using Microsoft.AspNet.Identity;

namespace EduComBoards.Controllers
{
  //  [Authorize]
    [RoutePrefix("api/Members")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class MembersController : ApiController
    {
        private BusinessModelDBContext db = new BusinessModelDBContext();
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db2 = new ApplicationDbContext();


        private UserRepository repository;

        public MembersController(UserRepository repo)
        {
            this.repository = repo;
        }
        public MembersController()
        {
            repository = new UserRepository();
        }

        // GET: api/Members/
        [HttpGet]
        [Route("getAllMembers")]
        [Authorize(Roles = "Member, Contributor, Moderator, Admin")]
        public List<ApplicationUser> GetMembers()
        {
            return repository.getAll();
        }

        [HttpGet]
        [Route("getMembers/{searchTerm}")]
        [ResponseType(typeof(List<ApplicationUser>))]
        public IHttpActionResult SearchMembers(string searchTerm)
        {
            List<ApplicationUser> applicationUsers = repository.getAll();
            applicationUsers = applicationUsers.Where(s => s.UserName.Contains(searchTerm)).ToList();
            if (applicationUsers == null)
            {
                return NotFound();
            }

            return Ok(applicationUsers);
        }

        // GET: api/Members/5
        [ResponseType(typeof(Member))]
        public IHttpActionResult GetMember(int id)
        {
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        // PUT: api/Members/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMember(string id, Member member)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (id != member.MemberID)
            //{
            //    return BadRequest();
            //}

            //db.Entry(member).State = EntityState.Modified;

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!MemberExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return StatusCode(HttpStatusCode.NoContent);
        }

        // PUT: api/Members/5
        [HttpPut]
        [Authorize(Roles = "Admin, Moderator")]
        [ResponseType(typeof(void))]
        public IHttpActionResult ChangeRole(int id, Member member, string[] roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != member.MemberID)
            {
                return BadRequest();
            }

            db.Entry(member).State = EntityState.Modified;
            
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!MemberExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        

        // POST: api/Members
        [ResponseType(typeof(Member))]
        public IHttpActionResult PostMember(Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Members.Add(member);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = member.MemberID }, member);
        }

        //POST: api/Members/postRequest
        [HttpPost]
        [Route("postRequest")]
        [Authorize(Roles = "Moderator, Contributor, Member")]
        public IHttpActionResult PostRequest(Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Requests.Add(request);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = request.MemberID }, request);
        }

        // DELETE: api/Members/5
        [ResponseType(typeof(Member))]
        public IHttpActionResult DeleteMember(int id)
        {
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return NotFound();
            }

            db.Members.Remove(member);
            db.SaveChanges();

            return Ok(member);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MemberExists(string id)
        {
            return repository.UserExists(id);
        }
    }
}