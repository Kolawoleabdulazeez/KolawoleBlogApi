using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class MakeCommentsDto
    {

        public required string Content { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }

    }

    public class UpdateComment
    {

        public required int Id { get; set; }
        public int Votes { get; set; }

        public  string? Content { get; set; }


    }

    public class GetCommentsDto
    {
        public  string? Content { get; set; }
    }

   

}
