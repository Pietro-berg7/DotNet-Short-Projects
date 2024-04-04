using AutoMapper;
using DDD_Model.Application.Models;
using DDD_Model.Domain.Entities;
using DDD_Model.Domain.Interfaces;
using DDD_Model.Infra.Data.Context;
using DDD_Model.Infra.Data.Repository;
using DDD_Model.Service.Services;
using Layer.Architecture.Application.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SqlServerContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("DDD-Model.Application")
    ));

builder.Services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
builder.Services.AddScoped<IBaseService<User>, BaseService<User>>();

builder.Services.AddSingleton(new MapperConfiguration(config =>
{
    config.CreateMap<CreateUserModel, User>();
    config.CreateMap<UpdateUserModel, User>();
    config.CreateMap<User, UserModel>();
}).CreateMapper());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
