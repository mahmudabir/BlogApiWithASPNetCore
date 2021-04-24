using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Threading;
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
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _db;

        public UsersController(IUnitOfWork db)
        {
            _db = db;
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var userFormDb = _db.User.Get(id);
            if (userFormDb != null)
            {
                return Ok(userFormDb);
            }
            return NoContent();
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult PutUser(User user)
        {
            if (ModelState.IsValid)
            {
                var userFromDb = _db.User.Get(user.Id);
                if (userFromDb != null)
                {
                    _db.User.Update(user);
                    _db.Save();
                    return Ok(user);
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize]
        [HttpPost("login")]
        public IActionResult PostLogin(User user)
        {
            if (ModelState.IsValid)
            {
                User userFromDB = _db.User.GetUserByUsernameNPassword(user.Username, user.Password);
                if (userFromDB != null)
                {
                    return Ok(userFromDB);
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Authorize]
        [HttpGet("logout")]
        public IActionResult GetLogout()
        {
            var username = HttpContext.User.Identity.Name;
            var isAdmin = HttpContext.User.IsInRole("Admin");
            var isAuthenticated = HttpContext.User.Identity.IsAuthenticated;
            var authenticationType = HttpContext.User.Identity.AuthenticationType;
            var claims = HttpContext.User.Claims;

            return Ok();
        }

        [HttpPost("register")]
        public IActionResult PostRegister(User user)
        {
            if (ModelState.IsValid)
            {
                User userFromDB = _db.User.GetUserByUsernameNPassword(user.Username, user.Password);
                if (userFromDB != null)
                {
                    return BadRequest("Username already exists");
                }
                else
                {
                    _db.User.Insert(user);
                    _db.Save();
                    return StatusCode(201);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
