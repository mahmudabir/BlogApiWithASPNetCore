using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlogApiWithASPNetCore.DataAccess.Repositories.IRepositories;

using Microsoft.AspNetCore.Mvc;

namespace BlogApiWithASPNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {

        private readonly IUnitOfWork _db;

        public RolesController(IUnitOfWork db)
        {
            _db = db;
        }


        [HttpGet("")]
        public IActionResult GetAllRoles()
        {
            return Ok(_db.Role.GetAll());
        }
    }
}
