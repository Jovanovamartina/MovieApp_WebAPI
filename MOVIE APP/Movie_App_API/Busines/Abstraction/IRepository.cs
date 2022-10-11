using MoviesApp.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busines.Abstraction
{
   public interface IRepository<T>
    {
        ICollection<T> GetAll();
        T GetById(int id);
        bool Update(T entity);
        bool Delete(int id);
    }
}
