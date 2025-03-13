using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Post : BaseModel
    {
        public string? Title { get; set; }

        [Required]
        public string PostContent { get; set; } = null!;

        // Foreign Key
        public int AuthorId { get; set; }

        // Navigation property
        [ForeignKey("AuthorId")]
        public User Author { get; set; } = null!;

        // Navigation for likes and comments
        public ICollection<Like> Likes { get; set; } = new List<Like>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }

}
