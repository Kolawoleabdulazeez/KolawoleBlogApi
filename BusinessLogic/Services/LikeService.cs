using AutoMapper;
using DataAccess.IRepositories;
using Domain.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class LikeService : ILikeService
    {

        private readonly ILikeRepository _likeRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public LikeService(ILikeRepository likeRepository, IPostRepository postRepository, IUserRepository userRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _postRepository = postRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public bool Like(LikesDto like, out string message )
        {
            Post? post = this._postRepository.FindBy(like.PostId);

            if(post is null)
            {
               message = "Can't perform like on an invalid post";
                return false;
            }

            User? user = this._userRepository.FindById(like.UserId);
            if (user is null)
            {
                message = "Invalid user can't perform like ";
                return false;
            }

            Like _like = _mapper.Map<Like>(like);
            Like? __like = this._likeRepository.Get(_like);
            if ( __like  is null)
            {
                this._likeRepository.Like(_like);
                message = "Like +1";
                return true;
            }
            this._likeRepository.UnLike(__like);
            message = "Unliked";
            return true;
           

           
        }

        //public bool UnLike(int id, out string message)
        //{
        //    Like? like = this._likeRepository.Get(id);
        //    if(like is null)
        //    {
        //        message = "Like not found";
        //        return false;
        //    }

        //    _likeRepository.UnLike(like);
        //    message = "Liked this post";
        //    return true;
        //}
        

    }
}
