using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [NotMapped]
        public string Role => "Admin,User";

        [JsonIgnore]
        internal ICollection<Post> Posts { get; set; }
        [JsonIgnore]
        internal ICollection<Comment> Comments { get; set; }
    }
}
