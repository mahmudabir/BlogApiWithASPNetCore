﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using BlogApiWithASPNetCore.DataAccess.Repositories;
using BlogApiWithASPNetCore.DataAccess.Repositories.IRepositories;

namespace BlogApiWithASPNetCore.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [JsonIgnore]
        public ICollection<Post> Posts { get; set; }
        [JsonIgnore]
        public ICollection<Comment> Comments { get; set; }
    }
}
