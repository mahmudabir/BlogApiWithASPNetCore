using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BlogApiWithASPNetCore.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public IFormFile Image { get; set; }

        //[NotMapped]
        //public string Role => "Admin,User";
    }
}
