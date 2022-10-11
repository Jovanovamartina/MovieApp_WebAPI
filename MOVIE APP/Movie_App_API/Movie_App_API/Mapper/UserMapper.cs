
using BookApp.DTO.UsersDto;
using Models;

namespace BookApp.Business.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToReqModel(this User source)
        {
            return new UserDto()
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Password = source.Password,
                Username = source.Username,
               
            };
        }

        public static User ToReqModel(this UserDto source)
        {
            return new User()
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Password = source.Password,
                Username = source.Username,
            
            };
        }
    }
}
