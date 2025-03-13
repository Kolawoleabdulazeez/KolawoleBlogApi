using DataAccess.Data;
using DataAccess.IRepositories;
using Domain.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class LikeRepository : ILikeRepository
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public LikeRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Like(Like like)
        {
            this._applicationDbContext.Likes.Add(like);
            this._applicationDbContext.SaveChanges();
        }


        public Like? Get(Like like)
        {
            return _applicationDbContext.Likes.SingleOrDefault(l => l.PostId == like.PostId && l.UserId == like.UserId);
        }

        public void UnLike(Like like)
        {
            _applicationDbContext.Likes.Remove(like);
            _applicationDbContext.SaveChanges();
        }

    }
}
