using BlogApplication.Data;
using BlogApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private PostDbContext _dbContext;
        public ApiController(PostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("posts")]
        public IActionResult Get()
        {
            try
            {
                var posts = _dbContext.Posts.ToList();
                if (posts.Count == 0)
                {
                    return StatusCode(404, "No post found!");
                }

                return Ok(posts);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occurred!");
            }
        }

        [HttpPost("createpost")]
        public IActionResult Create([FromBody] PostModel postrequest)
        {
            PostModel post = new PostModel();
            post.Title = postrequest.Title;
            post.PostContext = postrequest.PostContext;
            post.Author = postrequest.Author;
            try
            {
                _dbContext.Posts.Add(post);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occurred");
            }
            var posts = _dbContext.Posts.ToList();
            return Ok(posts);
        }

        [HttpPut("updatepost")]
        public IActionResult Update([FromBody] PostModel post)
        {
            try
            {
                var Post = _dbContext.Posts.FirstOrDefault(x => x.PostId == post.PostId);
                if(Post == null)
                {
                    return (StatusCode(404, "Post not found"));
                }
                Post.Title = post.Title;
                Post.PostContext = post.PostContext;
                Post.Author = post.Author;
                _dbContext.Entry(Post).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occurred");
            }
            var posts = _dbContext.Posts.ToList();
            return Ok(posts);
        }

        [HttpDelete("deletepost/{postId}")]
        public IActionResult Delete([FromRoute] PostModel post)
        {
            try
            {
                var Post = _dbContext.Posts.FirstOrDefault(x => x.PostId == post.PostId);
                if(Post == null)
                {
                    return StatusCode(404, "Post not found");
                }
                _dbContext.Entry(Post).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error has occurred");
            }
            var posts = _dbContext.Posts.ToList();
            return Ok(posts);
        }
    }
}
