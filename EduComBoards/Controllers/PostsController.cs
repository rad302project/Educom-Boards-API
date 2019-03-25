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
using EduComBoards.DAL;

namespace EduComBoards.Controllers
{

    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/Posts")]
    public class PostsController : ApiController
    {
        private BusinessModelDBContext db = new BusinessModelDBContext();

        public PostRepository repository;

        public PostsController(PostRepository repo)
        {
            this.repository = repo;
        }
        public PostsController()
        {
            repository = new PostRepository();
        }

        // GET: api/Posts
        public List<Post> GetPosts()
        {
            return repository.getAllPublic();
        }

        // GET: api/Posts/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult GetPost(int id)
        {
            Post post = repository.getPostById(id);
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
        [Route("createPrivatePost")]
        [ResponseType(typeof(PrivateDiscussionBoard))]
        public IHttpActionResult AddPostToPrivateDiscussionBoard(PrivatePost post)
        {
            PrivatePost privatePost = repository.CreatePrivate(post);
            return Content(HttpStatusCode.OK, post);
        }
        [HttpPost]
        [Route("createPublicPost")]
        [ResponseType(typeof(PrivateDiscussionBoard))]
        public IHttpActionResult AddPostToPublicDiscussionBoard(Post post)
        {
            Post publicPost = repository.CreatePublic(post);
            return Content(HttpStatusCode.OK, post);
        }


        [HttpGet]
        [Route("getPrivatePostByBoardID/{boardid}")]
        [ResponseType(typeof(List<PrivatePost>))]
        public IHttpActionResult getPrivatePostByBoardID(int boardid)
        {
            PrivatePost privatePosts = repository.getPrivatePostById(boardid);
            if (privatePosts == null)
            {
                return NotFound();
            }

            return Ok(privatePosts);
        }

        [Route("getPublicPostByBoardID/{boardid}"), HttpGet, ResponseType(typeof(List<Post>))]
        public IHttpActionResult getPublicPostByBoardID(int boardid)
        {
            List<Post> posts = repository.getPublicPostsByBoardId(boardid);
            if (posts == null)
            {
                return NotFound();
            }

            return Ok(posts);
        }

        // DELETE: api/Posts/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult DeletePrivatePost(int id)
        {
            repository.DeletePrivatePost(id);
            return Ok("deleting post");
        }
        public IHttpActionResult DeletePublicPost(int id)
        {
            repository.DeletePublicPost(id);
            return Ok("deleting post");
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