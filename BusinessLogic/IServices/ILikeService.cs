using Domain.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepositories
{
    public interface ILikeService
    {
        /// <summary>
        /// Like an post
        /// </summary>
        /// <param name="like"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        bool Like(LikesDto like, out string message);


        ///// <summary>
        ///// Unlike an post
        ///// </summary>
        ///// <param name="unlike"></param>
        ///// <param name="message"></param>
        ///// <returns></returns>
        //bool UnLike(int  likeId, out string message);
    }
}
