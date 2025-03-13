using Domain.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepositories
{
    public interface ICommentService
    {
        /// <summary>
        /// Creates a comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        Comment? CreateComment(MakeCommentsDto comment, out string message);

        /// <summary>
        /// Find a comment by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //Comment? FindCommentBy(int id, out string message);

        /// <summary>
        /// Finds all comments
        /// </summary>
        /// <returns></returns>
        //List<Comment> FindAllComments();

        /// <summary>
        /// Deletes a comment
        /// </summary>
        /// <param name="comment"></param>
        //bool DeleteComment(Comment comment, out string message);

        /// <summary>
        /// Updates a comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        Comment? UpdateComment(UpdateComment comment, out string message);

    }
}
