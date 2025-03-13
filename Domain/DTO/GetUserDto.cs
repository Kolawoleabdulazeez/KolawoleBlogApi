using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class GetUserDto 
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
    }

    public class LoginRequestDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public class CreateUserDto
    {
        public required string FirstName { get; set;  }
        public required string LastName { get; set; }
        public required string Password { get; set;  }
        public required string Email { get; set; }
    }

    public class UpdateUserDto
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
    }

    public class JwtUser
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
    }

}
