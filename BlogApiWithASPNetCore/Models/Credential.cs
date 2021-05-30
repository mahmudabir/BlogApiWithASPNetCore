using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApiWithASPNetCore.Models
{
    public class Credential
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Password { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        internal virtual User User { get; set; }



    }
}
