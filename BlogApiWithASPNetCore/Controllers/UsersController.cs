using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

using BlogApiWithASPNetCore.DataAccess.Repositories;
using BlogApiWithASPNetCore.DataAccess.Repositories.IRepositories;
using BlogApiWithASPNetCore.Models;
using BlogApiWithASPNetCore.Models.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace BlogApiWithASPNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public readonly IWebHostEnvironment _environment;
        public UsersController(IUnitOfWork db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
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

        [HttpPost("upload")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            //string path = Path.Combine(_environment.ContentRootPath, "Images/" + file.FileName);
            //using (var stream = new FileStream(path, FileMode.Create))
            //{
            //    await file.CopyToAsync(stream);
            //}
            //return Ok(file.FileName);

            if (file.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_environment.ContentRootPath + "\\Uploads\\Profile_Pictures\\"))
                    {
                        Directory.CreateDirectory(_environment.ContentRootPath + "\\Uploads\\Profile_Pictures\\");
                    }
                    // var fileName= Path.GetFileName(file.FileName);
                    var fileExtension = Path.GetExtension(file.FileName);
                    Console.WriteLine(fileExtension);
                    if (!CheckFileIfImageType(fileExtension))
                    {
                        return BadRequest("The File should be of jpg, jpeg, png type");
                    }
                    using (FileStream filestream = System.IO.File.Create(_environment.ContentRootPath + "\\Uploads\\Profile_Pictures\\" + HttpContext.User.Identity.Name + "_Profile_Picture" + fileExtension))
                    {
                        await file.CopyToAsync(filestream);
                        await filestream.FlushAsync();

                        var userFromDb = _db.User.GetUserByUsername(HttpContext.User.Identity.Name);

                        _db.User.SetUserProfilePicture(HttpContext.User.Identity.Name, "\\Uploads\\Profile_Pictures\\" + HttpContext.User.Identity.Name + "_Profile_Picture" + fileExtension);


                        //try
                        //{
                        //    string filePath = _environment.ContentRootPath + "\\Uploads\\Profile_Pictures\\" + HttpContext.User.Identity.Name + "_Profile_Picture" + fileExtension;
                        //    byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                        //    return Ok(fileBytes);
                        //}
                        //catch (Exception ex)
                        //{
                        //    return BadRequest(ex.ToString());
                        //}





                        return Ok("\\Uploads\\Profile_Pictures\\" + HttpContext.User.Identity.Name + "_Profile_Picture" + fileExtension);
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.ToString());
                }
            }
            else
            {
                return BadRequest("Unsuccessful");
            }
        }


        [HttpGet("download/{username}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> DownloadFile(string username)
        {
            try
            {
                var userFromDb = _db.User.GetUserByUsername(username);
                //string filePath = _environment.ContentRootPath + "\\Uploads\\Profile_Pictures\\" + HttpContext.User.Identity.Name + "_Profile_Picture" + ".jpg";
                string filePath = _environment.ContentRootPath + userFromDb.ImagePath;
                //byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
                //string fileName = HttpContext.User.Identity.Name + "_Profile_Picture" + ".jpg";
                var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                return new FileStreamResult(stream, "image/jpeg");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpDelete("delete/{username}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> DeleteFile(string username)
        {
            try
            {
                var userFromDb = _db.User.GetUserByUsername(username);

                if (System.IO.File.Exists(_environment.ContentRootPath + userFromDb.ImagePath))
                {
                    try
                    {
                        System.IO.File.Delete(_environment.ContentRootPath + userFromDb.ImagePath);
                        _db.User.SetUserProfilePicture(username, null);
                        return Ok("Deleted");
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.ToString());
                    }

                }
                return BadRequest("File does not exist");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // Non Action Methods
        [NonAction]
        private bool CheckFileIfImageType(string fileExtension)
        {
            string[] types = { ".jpg", ".jpeg", ".png" };

            bool flag = false;
            foreach (var item in types)
            {
                if (fileExtension.ToLower() == item)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
    }
}
