using Drugovich.Domain.Entities;
using Drugovich.Domain.Models.Enums;
using Drugovich.Infrastructure;
using Drugovich.Infrastructure.Data;
using Drugovich.Presentation.Config;
using Isopoh.Cryptography.Argon2;
using Microsoft.EntityFrameworkCore;

namespace Drugovich.Presentation
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            ConfigServices.Config(builder.Services, builder.Configuration);

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider
                    .GetRequiredService<DrugovichDbContext>();
                if (db.Database.CanConnect())
                {
                    db.Database.Migrate();
                    if (!db.Customers!.Any() && !db.CustomerGroups!.Any() && !db.Managers!.Any())
                    {
                        for (var i = 0; i < 2; i++)
                        {
                            var group = new CustomerGroup
                            {
                                Id = new Guid(),
                                GroupName = $"Group{i}",
                                Registered = DateTime.UtcNow,
                                LastUpdate = DateTime.UtcNow
                            };
                            db.CustomerGroups!.Add(group);
                            await db.SaveChangesAsync();

                            db.Customers!.Add(new Customer
                            {
                                Id = new Guid(),
                                Name = $"Customer{i}",
                                CNPJ = $"45.502.40{i}/0001-4{i}",
                                FK_CustomerGroup = group.Id,
                                Registered = DateTime.UtcNow,
                                LastUpdate = DateTime.UtcNow
                            });
                            await db.SaveChangesAsync();

                            db.Managers!.Add(new Manager
                            {
                                Id = new Guid(),
                                Name = $"ManagerLevel1-{i}",
                                Email = $"manager1-{i}@email.com",
                                Password = Argon2.Hash("123").ToString(),
                                Level = LevelEnum.Level1
                            });

                            db.Managers!.Add(new Manager
                            {
                                Id = new Guid(),
                                Name = $"ManagerLevel2-{i}",
                                Email = $"manager2-{i}@email.com",
                                Password = Argon2.Hash("123").ToString(),
                                Level = LevelEnum.Level2
                            });
                            await db.SaveChangesAsync();
                        }
                    }
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
