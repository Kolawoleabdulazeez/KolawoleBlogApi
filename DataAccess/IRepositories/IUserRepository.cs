using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Gets a single user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User? FindById(int id);

        /// <summary>
        /// 
        ///Gets all users
        /// </summary>
        /// <returns></returns>
        List<User> Find();

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="user"></param>
        void Delete(User user);

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        User Update(User user);


        /// <summary>
        /// Creates a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        User? Create(User user);

        /// <summary>
        /// Gets a single user by Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        User? FindByEmail(string email);

    }
}
