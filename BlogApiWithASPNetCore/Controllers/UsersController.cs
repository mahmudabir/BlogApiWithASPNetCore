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
using BlogApiWithASPNetCore.Models.ViewModels;

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


        [Authorize(Roles = "Admin")]
        [HttpGet("")]
        public IActionResult GetAllUsers()
        {
            var usersFormDb = _db.User.GetAll();
            if (usersFormDb != null)
            {
                return Ok(usersFormDb);
            }
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("roles/{designation}")]
        public IActionResult GetAllUsersByDesignation(string designation)
        {
            var usersFormDb = _db.User.GetAllUsersByDesignation(designation);
            if (usersFormDb.Count != 0)
            {
                return Ok(usersFormDb);
            }
            return NoContent();
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
        public IActionResult PutUser(int id, UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var userFromDb = _db.User.Get(id);
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
        public IActionResult PostLogin(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var userFromDB = _db.User.GetUserByUsernameNPassword(user.Username, user.Password);
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

        [HttpPost("register/{type}")]
        public IActionResult PostUserRegister(UserViewModel user, string type)
        {
            if (ModelState.IsValid)
            {
                var userFromDB = _db.User.GetUserByUsernameNPassword(user.Username, user.Password);
                if (userFromDB != null)
                {
                    return BadRequest("Username already exists");
                }
                else
                {
                    _db.User.Insert(user, type);
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
