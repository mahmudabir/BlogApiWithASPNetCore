using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlogApiWithASPNetCore.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Designation { get; set; }

        [JsonIgnore]
        internal ICollection<User> Users { get; set; }
    }
}
