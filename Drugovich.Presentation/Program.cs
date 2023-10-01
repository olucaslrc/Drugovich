using Drugovich.Domain.Entities;
using Drugovich.Domain.Models.Enums;
using Drugovich.Infrastructure;
using Drugovich.Infrastructure.Data;
using Drugovich.Presentation.Config;
using Microsoft.EntityFrameworkCore;

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
        
            //for (var i = 0; i < 10; i++)
            //{
            //    var group = new CustomerGroup
            //    {
            //        Id = new Guid(),
            //        GroupName = $"Group{i}",
            //        Registered = DateTime.UtcNow,
            //        LastUpdate = DateTime.UtcNow
            //    };
            //    db.CustomerGroups!.Add(group);
            //    await db.SaveChangesAsync();

            //    db.Customers!.Add(new Customer
            //    {
            //        Id = new Guid(),
            //        CNPJ = $"45.502.40{i}/0001-4{i}",
            //        FK_CustomerGroup = group.Id,
            //        Registered = DateTime.UtcNow,
            //        LastUpdate = DateTime.UtcNow
            //    });
            //    await db.SaveChangesAsync();

            //    db.Managers!.Add(new Manager
            //    {
            //        Id = new Guid(),
            //        Email = $"manager{i}@email.com",
            //        Level = LevelEnum.Level1
            //    });
            //    await db.SaveChangesAsync();
            //}
        //await db.Database.MigrateAsync();
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
