using Domain.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepositories
{
    public interface ILikeRepository
    {
        


        /// <summary>
        /// Get like by Id
        /// </summary>
        /// <param name="unlike"></param>

        /// <returns></returns>
        Like? Get (Like like);


        /// <summary>
        /// Like an post
        /// </summary>
        /// <param name="like"></param>

        /// <returns></returns>
        void Like(Like like);


        /// <summary>
        /// unLike an post
        /// </summary>
        /// <param name="like"></param>

        /// <returns></returns>
        void UnLike(Like like);

    }
}
