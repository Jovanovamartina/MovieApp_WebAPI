using AutoMapper;
using BookApp.Business.Abstraction;
using BookApp.DTO.UsersDto;
using BookApp.HelperMethods;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IGenerateToken _token;
        private readonly IHasher _hasher;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository,IGenerateToken token, IHasher hasher, IMapper mapper)
        {
            _userRepository = userRepository;
            _token = token;
            _hasher = hasher;
            _mapper = mapper;
        }
     
    }
}
