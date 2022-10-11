using AutoMapper;
using BookApp.DTO.UsersDto;
using BookApp.Exceptions.UserExceptions;
using BookApp.HelperMethods;
using Busines.Abstraction;
using Data.Interfaces;
using Models;


namespace Busines.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IGenerateToken _token;
        private readonly IHasher _hasher;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IGenerateToken token, IHasher hasher, IMapper mapper)
        {
            _userRepository = userRepository;
            _token = token;
            _hasher = hasher;
            _mapper = mapper;
        }
        public string Authenticate(UserLoginDto userDto)
        {
            User user = _userRepository.GetUser(userDto.Username);
            var password = _hasher.Hash(userDto.Password);

            if (user != null && password == user.Password)
            {
                return _token.Token(user.Id, user.Username);
            }
            else
            {
                throw new UserException("User is not found");
            }
        }

        public void DeleteUser(int id)
        {
            var book = _userRepository.GetById(id);

            if (book != null)
            {
                _userRepository.Delete(book);
            }
            else
            {
                throw new UserException("Book not found");
            }
        }

        public void ForgotPassword(UpdateUserDto user)
        {
            if (user.NewPassword == user.ConfirmPassword)
            {
                User userModel = _userRepository.GetUser(user.Username);

                if (userModel != null)
                {
                    User newUser = new()
                    {
                        Id = userModel.Id,
                        FirstName = userModel.FirstName,
                        LastName = userModel.LastName,
                        Username = userModel.Username,
                        Password = _hasher.Hash(user.NewPassword)
                    };
                    _userRepository.Update(newUser);
                }
                else
                {
                    throw new UserException("User with that username does not exist");
                }
            }
            else
            {
                throw new UserException("Passwords don't match");
            }
        }

        public List<UserDto> GetUsers()
        {
            var users = _userRepository.GetAll().Select(x => _mapper.Map<UserDto>(x)).ToList();
            return users;
        }

        public void RegisterUser(RegisterUserDto user)
        {
            if (GetUsers().Any(x => x.Username == user.Username))
            {
                throw new UserException("username taken");
            }
            else
            {
                User userDto = new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.Username,
                    Password = _hasher.Hash(user.Password)

                };
                _userRepository.Add(userDto);
            }
        }
    }
}
