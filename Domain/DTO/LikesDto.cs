using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class LikesDto
    {
        public int UserId { get; set; }

        public int PostId { get; set; }
    }

    public class GetLikes
    {
        public int PostId { get; set; }
        public string? PostTitle { get; set; }

    }

    public class GetLikesForPostsDto
    {
        public string? UserName { get; set; }
    }

}
