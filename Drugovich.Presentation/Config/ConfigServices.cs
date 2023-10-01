using Drugovich.Application.AutoMapper;
using Drugovich.Domain.Entities;
using Drugovich.Domain.Interfaces;
using Drugovich.Domain.Interfaces.Repositories;
using Drugovich.Infrastructure;
using Drugovich.Infrastructure.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Drugovich.Presentation.Config
{
    public static class ConfigServices
    {
        public static IServiceCollection Config(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DrugovichDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            // Dependency Injection
            services.AddTransient<IUnityOfWork, UnityOfWork>();
            services.AddTransient<IMediator, Mediator>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IManagerRepository, ManagerRepository>();
            services.AddTransient<ICustomerGroupRepository, CustomerGroupRepository>();

            // Custom
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            // Queries
            //services.AddTransient<IRequestHandler<GetProductsQuery, IEnumerable<ProductDTO>>, GetProductsQueryHandler>();

            //// Commands
            //services.AddTransient<IRequestHandler<AddProductCommand, HttpResponseMessage>, AddProductCommandHandler>();

            // AutoMapper
            services.AddAutoMapper(typeof(Profiles));

            // Authentication & Authorization
            services.AddIdentity<Manager, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            return services;
        }
    }
}
