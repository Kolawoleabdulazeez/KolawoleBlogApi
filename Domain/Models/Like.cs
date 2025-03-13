using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Like : BaseModel
    {
        public int UserId { get; set; }
        public int PostId { get; set; }

        public User User { get; set; } = null!;
        public Post Post { get; set; } = null!;



    }

   

}


