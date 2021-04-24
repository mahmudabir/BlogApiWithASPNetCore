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
    [Route("api/posts/{pid}")]
    public class CommentsController : ControllerBase
    {
        private readonly IUnitOfWork _db;

        public CommentsController(IUnitOfWork db)
        {
            _db = db;
        }

        [HttpGet("comments")]
        public IActionResult Get(int pid)
        {
            var commentFromDB = _db.Comment.GetAllCommentsByPost(pid);

            if (commentFromDB != null)
            {
                return Ok(commentFromDB);
            }
            else
            {
                return BadRequest("empty");
            }
        }

        [HttpGet("comments/{cid}")]
        public IActionResult GetCommentByID(int pid, int cid)
        {
            var commentFromDB = _db.Comment.GetPostCommentByID(pid, cid);

            if (commentFromDB != null)
            {
                return Ok(commentFromDB);
            }
            else
            {
                return BadRequest("empty");
            }
        }

        [HttpPost("comments")]
        public IActionResult Post(Comment comment)
        {
            comment.CommentTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                _db.Comment.Insert(comment);
                string uri = Url.Link("GetCommentByID", new { pid = comment.PostId, cid = comment.Id });
                return Created(uri, comment);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpPut("comments/{cid}")]
        public IActionResult Put(int pid, int cid, Comment comment)
        {
            if (ModelState.IsValid)
            {

                var commentFromDB = _db.Comment.GetPostCommentByID(pid, cid);
                if (commentFromDB != null)
                {
                    _db.Comment.Update(comment);
                    return Ok(comment);
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


        [HttpDelete("comments/{cid}")]
        public IActionResult Delete(int cid)
        {
            var commentFromDB = _db.Comment.Get(cid);

            if (commentFromDB != null)
            {
                _db.Comment.Delete(cid);
                return NoContent();
            }
            else
            {
                return BadRequest("Post Not Found");
            }
        }

    }
}
