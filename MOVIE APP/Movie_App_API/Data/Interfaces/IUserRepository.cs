using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUserRepository
    {
        void Add(User entity);
        void Delete(User entity);
        void Update(User entity);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User GetUser(string username);
    }
}
