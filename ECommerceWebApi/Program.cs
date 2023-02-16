using BusinessLayer.Implementation;
using BusinessLayer.Interface;
using DataAccessLayer.Db;
using ECommerceWebApi.GlobalExcptionHandling;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<EcDbContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("conn")
    , dbOpt => dbOpt.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name))
);
builder.Services.AddTransient<IRole,RoleImp>();
builder.Services.AddTransient<IProduct, ProductImp>();
builder.Services.AddTransient<IUser, UserImp>();
builder.Services.AddTransient<ICategory, CategoryImp>();


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
