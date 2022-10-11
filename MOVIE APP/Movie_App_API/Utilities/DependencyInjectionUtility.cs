using AutoMapper;
using BookApp.HelperMethods;
using Busines.Abstraction;
using Busines.Implementation;
using Data;
using Data.Interfaces;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoviesApp.Interfaces;
using MoviesApp.Repository;

namespace Utilities
{
    public static class DependencyInjectionUtility
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection service, string connectionString)
        {
            //sql
            service.AddDbContext<DataContext>(options =>
            options.UseSqlServer(connectionString));

            //services
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IHasher, Hashing>();
            service.AddScoped<IGenerateToken, GenerateToken>();
            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<ICountryRepository, CountryRepository>();
            service.AddScoped<IProducerRepository, ProducerRepository>();
            service.AddScoped<IMovieRepository, MovieRepository>();
            service.AddScoped<IReviewerRepository, ReviewerRepository>();
            service.AddScoped<IReviewRepository, ReviewRepository>();
            service.AddScoped<ICountryService, CountryService>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<IMovieService, MovieService>();
            service.AddScoped<IProducerService, ProducerService>();
            service.AddScoped<IReviewService,ReviewService>();
            service.AddScoped<IReviewerService, ReviewerService>();

            return service;

        }
    }
}
