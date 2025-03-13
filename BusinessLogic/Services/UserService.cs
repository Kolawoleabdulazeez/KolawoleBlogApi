using AutoMapper;
using BusinessLogic.IServices;
using DataAccess.IRepositories;
using Domain.DTO;

//using DataAccess.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly JwtService _jwtService;

        public UserService(IUserRepository userRepository, IMapper mapper, JwtService jwtService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public User? CreateUser(CreateUserDto user, out string message)
        {
            User _user = _mapper.Map<User>(user);

            User? newUser = _userRepository.Create(_user);
            if (newUser is null)
            {
                message = "ERROR creating new User.";

            }
            message = "User created successfully";
            return newUser;

        }

        //public bool Delete(int id, out string message)
        //{
        //    User? deleteUser = _userRepository.FindById(id);
        //    if (deleteUser is null)
        //    {
        //        message = "User doesn't exists.";
        //        return false;
        //    }
        //    message = "User deleted successfully";
        //    _userRepository.Delete(deleteUser);
        //    return true;

        //}

        //public List<User> FindAll()
        //{
        //    return _userRepository.Find();
        //}

        public GetUserDto? FindUserBy(object identifier, out string message)
        {
            User? user = null;
            if (identifier is int id)
            {
                if (id < 1)
                {
                    message = "Invalid Id";
                    return null;
                }
                user = _userRepository.FindById(id);
                if (user is null)
                {
                    message = "User not Found";
                    return null;
                }
            }
            else if (identifier is string email)
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email))
                {
                    message = "Invalid email address";
                    return null;
                }
                user = _userRepository.FindByEmail(email);
                if (user is null)
                {
                    message = "User not Found";
                    return null;
                }

            }
            else
            {
                message = "Unsupported identifier type";
                return null;
            }

            message = "User retrived successfully.";
            GetUserDto _user = _mapper.Map<GetUserDto>(user);
            return _user;
        }

        public User? UpdateUser(UpdateUserDto user, out string message)
        {

            User _user = _mapper.Map<User>(user);
            User? existingUser = _userRepository.FindById(_user.Id);
            if (existingUser is null)
            {
                message = "User doesn't exists.";
                return null;
            }
            if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrEmpty(user.FirstName))
            {
                message = "Blank first name field";
                return null;
            }

            existingUser.FirstName = user.FirstName;
            _userRepository.Update(existingUser);
            message = "User name updated succesfully.";
            return existingUser;
        }

        public User? LoginUser(LoginRequestDto model, out string message)
        {
            User? user =  _userRepository.FindByEmail(model.Email);

            //var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
            //if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))

            if (user == null || model.Password != user?.Password)
            {
                message = "Invalid credentials";
                return null;
            }

            message = _jwtService.GenerateJwtToken(_mapper.Map<JwtUser>(user));
            return user;
        }

        public bool LogoutUser(int Id, out string message)
        {
            User? user = _userRepository.FindById(Id);
            if(user is null)
            {
                message = "Error logging out";
                return false;
            }
            //Perform logout operation
            message = "User has been logged out";
            return true;

        }
    }
}
