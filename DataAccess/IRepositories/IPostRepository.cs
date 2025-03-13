using Domain.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepositories
{
    public interface IPostRepository
    {

        /// <summary>
        /// Creates an post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        Post? Create(Post post);

        /// <summary>
        /// Updates an post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        Post? Update(Post post);

        /// <summary>
        /// Finds an post by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       Post? FindBy(int id);


        /// <summary>
        /// Deleets an post
        /// </summary>
        /// <param name="post"></param>
        void Delete(Post post);

        /// <summary>
        /// Finds all posts
        /// </summary>
        /// <returns></returns>
        List<Post> Find();
    }
}
