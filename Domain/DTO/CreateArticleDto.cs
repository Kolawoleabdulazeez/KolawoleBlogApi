using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class CreatePostDto
    {

        public  string? Title { get; set; }

        public required string PostContent { get; set; }

        public required int AuthorId { get; set;  }

    }

    public class UpdatePost
    {

        public required int Id { get; set; }
        public string? Title { get; set; }
        public string? PostContent { get; set; }


    }

    public class GetPostDto : UpdatePost 
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public List<GetCommentsDto>? Comments { get; set; } = new();

        public int LikeCount { get; set; } // New property for like count

    }


    public class GetListOfPosts : UpdatePost
    {
     
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;


    }

}
