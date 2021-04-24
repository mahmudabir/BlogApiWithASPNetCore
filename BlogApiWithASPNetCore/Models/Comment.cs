using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApiWithASPNetCore.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CommentTime { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        internal User User { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        internal Post Post { get; set; }
    }
}
