using DataAccess.Data;
using DataAccess.IRepositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CommentRepository : ICommentRepository
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public CommentRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Comment? Create(Comment comment)
        {
            _applicationDbContext.Comments.Add(comment);
            _applicationDbContext.SaveChanges();
            return comment ?? null;
        }

        public void Delete(Comment comment)
        {
            _applicationDbContext.Comments.Remove(comment);
        }

        public List<Comment> Find()
        {
            return _applicationDbContext.Comments.ToList();
        }

        public Comment? FindBy(int id)
        {
            return _applicationDbContext.Comments.Find(id);

        }

        public Comment Update(Comment comment)
        {
            _applicationDbContext.Comments.Update(comment);
            return comment;
        }
    }
}
