using AutoMapper;
using BusinessLayer.Implementation;
using BusinessLayer.Interface;
using DataAccessLayer.Db;
using ECommerceWebApi;
using ECommerceWebApi.GlobalExcptionHandling;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();




builder.Services.MethodJWT(builder.Configuration)
                .Repo()
                .Context(builder.Configuration)
                .Swager()
                .AddNewtonJson();


string Connectionstring = builder.Configuration.GetConnectionString("conn");
string tableName = "Logs";

// Serilog with database
var _logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.MSSqlServer(Connectionstring, tableName).CreateLogger();
builder.Logging.AddSerilog(_logger);




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

app.UseMiddleware<GlobalExceptionHandling>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
