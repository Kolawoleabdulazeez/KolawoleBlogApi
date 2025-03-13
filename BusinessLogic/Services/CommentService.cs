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
    public class CommentService : ICommentService
    {

        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CommentService (ICommentRepository commentRepository, IPostRepository postRepository, IUserRepository userRepository, IMapper mapper) 
        {
            this._commentRepository = commentRepository;
            _postRepository = postRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            
        }

        public Comment? CreateComment(MakeCommentsDto comment, out string message)
        {

            if ( string.IsNullOrWhiteSpace(comment.Content) )
            {
                message = "Empty comment field";
                return null;
            }

            if (_postRepository.FindBy(comment.PostId) is null)
            {
                message = "Can't comment on an invalid Post";
                return null;
            }

            if ( _userRepository.FindById(comment.UserId) is null )
            {
                message = "Invalid user trying to comment";
                return null;
            }
            Comment _comment = _mapper.Map<Comment>(comment);

            message = (_commentRepository.Create(_comment) is null) ? "Error commenting on this post" : "Comment successfully";
            return _comment;
        }

        public bool DeleteComment(Comment comment, out string message)
        {
            Comment? existingComment = _commentRepository.FindBy(comment.Id);
            if (existingComment is null)
            {
                message = "Null reference : Existing document";
                return false;

            }
            message = "Delete successful";
            _commentRepository.Delete(existingComment);
            return true;
        }

        public List<Comment> FindAllComments()
        {
           return  _commentRepository.Find().ToList();
        }

        public Comment? FindCommentBy(int id, out string message)
        {
            if (id < 0)
            {
                message = "Invalid comment";
                return null;
                //throw new ArgumentException();
            }
            message = "Find comment By id";
            return _commentRepository.FindBy(id);
        }

        public Comment? UpdateComment(UpdateComment comment, out string message)
        {
            Comment? existingComment = _commentRepository.FindBy(comment.Id);
            if(existingComment is null) 
            {
                message = "Null reference : Existing document";
                throw new ArgumentNullException();
            }

            if (!string.IsNullOrWhiteSpace(comment.Content)) 
            {
                existingComment.Content = comment.Content;
            }
            if (comment.Votes >  0) {

                existingComment.Votes += comment.Votes;
            }

            
          
            _commentRepository.Update(existingComment);
            message = "Update successful";
            return existingComment;
        }
    }
}
