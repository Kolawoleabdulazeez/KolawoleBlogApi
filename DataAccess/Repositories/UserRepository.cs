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
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public User? Create(User user)
        {
            _applicationDbContext.Users.Add(user);
             _applicationDbContext.SaveChanges();
            return user ?? null;

        }

        public void Delete(User user)
        {
            _applicationDbContext.Users.Remove(user);
            _applicationDbContext.SaveChanges();
        }

        public List<User> Find()
        {
            return _applicationDbContext.Users.ToList();
            
        }

        public User? FindById(int id)
        {
            return _applicationDbContext.Users.Find(id);
        }

        public User? FindByEmail(string email)
        {
            return _applicationDbContext.Users.FirstOrDefault(u => u.Email == email);
        }

        public User Update(User user)
        {
            _applicationDbContext.Users.Update(user);
            _applicationDbContext.SaveChanges();
            return user;
        }
    }
}
