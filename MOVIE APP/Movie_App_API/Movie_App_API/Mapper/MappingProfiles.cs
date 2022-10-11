using AutoMapper;
using BookApp.DTO.UsersDto;
using Models;
using MoviesApp.Dto;

namespace Movie_App_API.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<MovieDto, Movie>();
            CreateMap<ProducerDto, Producer>();
            CreateMap<CountryDto, Country>();
            CreateMap<CategoryDto, Category>();
            CreateMap<ReviewDto, Review>();
            CreateMap<ReviewerDto, Reviewer>();

           
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<User, RegisterUserDto>();
            CreateMap<RegisterUserDto, User>();
            CreateMap<User, UserLoginDto>();
            CreateMap<UserLoginDto, User>();
        }
    }
}
