using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.HelperMethods
{
    public interface IHasher
    {
        public string Hash(string password);
    }
}
