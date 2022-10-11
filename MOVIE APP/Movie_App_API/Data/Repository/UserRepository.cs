using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dbContext;
        public UserRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(User entity)
        {
            _dbContext.Users.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users; ;
        }

        public User GetById(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id == id);
        }

        public User GetUser(string username)
        {
            return GetAll().SingleOrDefault(x => x.Username == username);
        }

        public void Update(User entity)
        {
            User user = GetById(entity.Id);
            _dbContext.Entry(user).CurrentValues.SetValues(entity);
            _dbContext.SaveChanges();
        }
    }
}
