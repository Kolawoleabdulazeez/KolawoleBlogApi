using AutoMapper;
using DataAccess.IRepositories;
using DataAccess.Repositories;
using Domain.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class PostService : IPostService
    {

        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }


        public Post? CreatePost(CreatePostDto post, out string message)
        {
            Post _post = _mapper.Map<Post>(post);
            Post? newPost = _postRepository.Create(_post);
            message = (newPost is null) ? "Error creating new post" : "Post created successfully";
            return newPost;
        }

        public bool DeletePost(int id, out string message)
        {
            Post? existingPost = _postRepository.FindBy(id);
            if (existingPost is null)
            {
                message = "Error deleting post";
                    return false;
            }

            _postRepository.Delete(existingPost);
            message = "Post deleted successfully";
            return true;

        }

        public List<GetListOfPosts> FindAllPosts()
        {
            return _mapper.Map<List<GetListOfPosts>>(_postRepository.Find().ToList());
        }


        public GetPostDto? FindPostBy(int id, out string message)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            Post? post = _postRepository.FindBy(id);
            message = (post is null) ? "Post not found" : "Success";

            GetPostDto _post = _mapper.Map<GetPostDto>(post);
            return _post;
        }



        
        public Post? UpdatePost(UpdatePost post, out string message)
        {
            Post? existingPost = _postRepository.FindBy(post.Id);
            if (existingPost is null)
            {
                throw new NullReferenceException();
            }


            if (string.IsNullOrWhiteSpace(post.PostContent))
            {
                message = "Post cant be blank";
                return null;
            }

            existingPost.PostContent = post.PostContent ?? existingPost.PostContent;

            message = "Post updated successfully";
            _postRepository.Update(existingPost);
            return existingPost;

        }
    }
}
