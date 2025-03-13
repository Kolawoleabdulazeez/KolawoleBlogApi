using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepositories
{
    public interface ICommentRepository
    {
        /// <summary>
        /// Creates a comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        Comment? Create(Comment comment);

        /// <summary>
        /// Find a comment by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Comment? FindBy(int id);

        /// <summary>
        /// Finds all comments
        /// </summary>
        /// <returns></returns>
        List<Comment> Find();

        /// <summary>
        /// Deletes a comment
        /// </summary>
        /// <param name="comment"></param>
        void Delete(Comment comment);

        /// <summary>
        /// Updates a comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        Comment Update(Comment comment);

    }
}
