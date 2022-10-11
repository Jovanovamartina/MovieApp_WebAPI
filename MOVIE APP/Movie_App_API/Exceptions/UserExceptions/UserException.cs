using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Exceptions.UserExceptions
{
    public class UserException :Exception
    {
        public UserException():base("Something went wrong")
        {

        }
        public UserException(string message):base(message)
        {

        }
    }
}
