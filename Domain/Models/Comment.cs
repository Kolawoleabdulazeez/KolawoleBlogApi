using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Comment : BaseModel
    {

        public required string Content { get; set; }

        public int Votes { get; set; }

        // Foreign Keys
        public int UserId { get; set; }
        public int PostId { get; set; }

        public Post Post { get; set; } = null!;
        public User User { get; set; } = null!;



    }

}
