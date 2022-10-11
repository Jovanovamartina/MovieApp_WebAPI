using BookApp.DTO.UsersDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Business.Abstraction
{
    public interface IUserService<User>
    {
        void RegisterUser(RegisterUserDto user);
        string Authenticate(UserLoginDto user);
        void ForgotPassword(UpdateUserDto user);
        List<UserDto> GetUsers();
       
      
    }
}
