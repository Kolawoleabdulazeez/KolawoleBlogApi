using Domain.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.Services.PostService;

namespace DataAccess.IRepositories
{
    public interface IPostService
    {

        /// <summary>
        /// Creates an post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        Post? CreatePost(CreatePostDto post, out string message);

        /// <summary>
        /// Updates an post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        Post? UpdatePost(UpdatePost post, out string message);

        /// <summary>
        /// Finds an post by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GetPostDto? FindPostBy(int id, out string message);


        /// <summary>
        /// Deleets an post
        /// </summary>
        /// <param name="post"></param>
        bool DeletePost(int Id, out string message);

        /// <summary>
        /// Finds all posts
        /// </summary>
        /// <returns></returns>
        List<GetListOfPosts> FindAllPosts();
    }
}
