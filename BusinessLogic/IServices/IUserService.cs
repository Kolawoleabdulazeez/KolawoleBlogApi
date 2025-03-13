using Domain.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IServices
{
    public interface IUserService
    {
        /// <summary>
        /// Gets a single user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GetUserDto? FindUserBy(object identifier, out string message);

        ///// <summary>
        ///// 
        /////Gets all users
        ///// </summary>
        ///// <returns></returns>
        //List<User> FindAll();

        ///// <summary>
        ///// Deletes a user
        ///// </summary>
        ///// <param name="user"></param>
        //bool Delete(int id, out string message);

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        User? UpdateUser(UpdateUserDto user, out string message);


        /// <summary>
        /// Creates a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        User? CreateUser(CreateUserDto user, out string message   );

        
        /// <summary>
        /// Log In user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        User? LoginUser(LoginRequestDto user, out string message);


        /// <summary>
        /// Log Out user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        bool LogoutUser(int Id, out string message);


    }
}
