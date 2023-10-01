using Drugovich.Application.AutoMapper;
using Drugovich.Application.Commands.Security;
using Drugovich.Application.Commands.Security.Handlers;
using Drugovich.Application.DTOs.App;
using Drugovich.Application.Services.Security;
using Drugovich.Application.Tools;
using Drugovich.Domain.Interfaces;
using Drugovich.Domain.Interfaces.Repositories;
using Drugovich.Domain.Interfaces.Services;
using Drugovich.Infrastructure;
using Drugovich.Infrastructure.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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
            services.AddTransient<ITokenService, TokenService>();

            // Custom
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Drugovich API",
                    Version = "v1"
                });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Bearer",
                    Description = "Insert your JWT Token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        securityScheme,
                        new[] { "Bearer" }
                    }
                });
            });

            // Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            // Queries
            //services.AddTransient<IRequestHandler<GetProductsQuery, IEnumerable<ProductDTO>>, GetProductsQueryHandler>();

            //// Commands
            services.AddTransient<IRequestHandler<RegisterManagerCommand, ManagerDTO>, RegisterManagerCommandHandler>();
            services.AddTransient<IRequestHandler<LoginManagerCommand, ManagerDTO>, LoginManagerCommandHandler>();

            // AutoMapper
            services.AddAutoMapper(cfg =>
            {
                cfg.AllowNullCollections = true;
            }, typeof(Profiles));

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true

                };
            });

            return services;
        }
    }
}
