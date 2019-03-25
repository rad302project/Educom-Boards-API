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
using EduComBoards.DAL.Post;

namespace EduComBoards.Controllers
{

    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/Posts")]
    public class PostsController : ApiController
    {
        private BusinessModelDBContext db = new BusinessModelDBContext();

        public IPostRepository repository;

        public PostsController(IPostRepository repo)
        {
            this.repository = repo;
        }
        public PostsController()
        {
            repository = new IPostRepo();
        }

        // GET: api/Posts
        public List<Post> GetPosts()
        {
            return repository.GetAll();
        }

        // GET: api/Posts/5
        [ResponseType(typeof(Post))]
        public async Task<IHttpActionResult> GetPost(int id)
        {
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // PUT: api/Posts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPost(int id, Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.ID)
            {
                return BadRequest();
            }

            db.Entry(post).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
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
        [Route("postPost")]
        [ResponseType(typeof(PrivateDiscussionBoard))]
        public async Task<IHttpActionResult> AddPostToPrivateDiscussionBoard(PrivatePost post)
        {
            using (BusinessModelDBContext db = new BusinessModelDBContext())
            {
                db.PrivatePosts.Add(post);
                db.SaveChanges();
                return Content(HttpStatusCode.OK, post);
            }
        }


        // DELETE: api/Posts/5
        [ResponseType(typeof(Post))]
        public async Task<IHttpActionResult> DeletePost(int id)
        {
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            db.Posts.Remove(post);
            await db.SaveChangesAsync();

            return Ok(post);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostExists(int id)
        {
            return db.Posts.Count(e => e.ID == id) > 0;
        }
    }
}