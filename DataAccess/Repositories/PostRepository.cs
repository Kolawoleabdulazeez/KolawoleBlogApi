using DataAccess.Data;
using DataAccess.IRepositories;
using Domain.DTO;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PostRepository : IPostRepository
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public PostRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Post? Create(Post post)
        {

            _applicationDbContext.Posts.Add(post);
            _applicationDbContext.SaveChanges();
            return post ?? null;
        }

        public void Delete(Post post)
        {
            _applicationDbContext.Posts.Remove(post);
            _applicationDbContext.SaveChanges();
        }

        public List<Post> Find()
        {
            return _applicationDbContext.Posts.ToList();
        }

        public Post? FindBy(int id)
        {
            return  _applicationDbContext.Posts
                .Include(a => a.Author)
                .Include(a => a.Comments) // Include comments as well
                .Include(a => a.Likes)
                .FirstOrDefault(a => a.Id == id);
        }

        public Post Update(Post post)
        {
            _applicationDbContext.Posts.Update(post);
            _applicationDbContext.SaveChanges();
            return post;

        }
    }
}
