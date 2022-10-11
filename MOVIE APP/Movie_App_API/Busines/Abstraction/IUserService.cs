using BookApp.DTO.UsersDto;


namespace Busines.Abstraction
{
    public interface IUserService
    {
        void RegisterUser(RegisterUserDto user);
        string Authenticate(UserLoginDto user);
        void ForgotPassword(UpdateUserDto user);
        List<UserDto> GetUsers();
        void DeleteUser(int id);
    }
}
