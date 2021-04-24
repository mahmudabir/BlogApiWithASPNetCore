using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using BlogApiWithASPNetCore.DataAccess.Repositories;
using BlogApiWithASPNetCore.DataAccess.Repositories.IRepositories;
using BlogApiWithASPNetCore.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApiWithASPNetCore.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IUnitOfWork _db;

        public PostsController(IUnitOfWork db)
        {
            _db = db;
        }

        [HttpGet("")]
        public IActionResult GetAllPost()
        {
            return Ok(_db.Post.GetAll().OrderByDescending(x => x.PostTime));
        }

        [HttpGet("{id}")]
        public IActionResult GetGetPostByID(int id)
        {
            var postFromDB = _db.Post.Get(id);

            if (postFromDB != null)
            {
                return Ok(postFromDB);
            }
            else
            {
                return BadRequest("Post Not Found");
            }
        }



        [HttpGet("search/{s}")]
        public IActionResult GetPostSearch(string s = "")
        {
            var postFromDB = _db.Post.PostSearch(s);

            if (postFromDB != null)
            {
                return Ok(postFromDB);
            }
            else
            {
                return BadRequest("No Post Found");
            }
        }


        [HttpPost("")]
        public IActionResult Post(Post post)
        {
            post.PostTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                _db.Post.Insert(post);
                string uri = Url.Link("GetPostByID", new { id = post.Id });
                return Created(nameof(GetGetPostByID), post);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Post post)
        {
            if (ModelState.IsValid)
            {

                var postFromDB = _db.Post.Get(id);

                if (postFromDB != null)
                {
                    _db.Post.Update(post);
                    return Ok(post);
                }
                else
                {
                    return BadRequest("Post Not Found");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var postFromDB = _db.Post.Get(id);

            if (postFromDB != null)
            {
                _db.Post.Delete(id);
                return NoContent();
            }
            else
            {
                return BadRequest("Post Not Found");
            }
        }

    }
}
