

using BusinessLayer.Implementation;
using BusinessLayer.Interface;
using DataAccessLayer.Db;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace ECommerceWebApi;

public static class ExtensionMethods
{
    public static IServiceCollection Swager(this IServiceCollection services)
    {

        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });
        return services;
    }

    public static IServiceCollection MethodJWT(this IServiceCollection services, IConfiguration configuration)
    {
        //?--------------------------JWT authentication ---------------------------------------------

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
        return (services);

    }


    //public static IServiceCollection Context(this IServiceCollection services, IConfiguration configuration)
    //{
    //    services.AddDbContext<EcDbContext>(options => options
    //    .UseSqlServer(configuration.GetConnectionString("conn")
    //   , dbOpt => dbOpt.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name)));

    //    return services;
    //}


    public static IServiceCollection Repo(this IServiceCollection services)
    {
        services.AddTransient<IRole, RoleImp>();
        services.AddTransient<IProduct, ProductImp>();
        services.AddTransient<IUser, UserImp>();
        services.AddTransient<ICategory, CategoryImp>();
        services.AddTransient<IAuth, AuthImp>();
        services.AddTransient<IOrder, OrderImp>();

        return services;
    }


    #region NewtonSoftJson

    public static IServiceCollection AddNewtonJson(this IServiceCollection services)
    {
        services.AddControllersWithViews()
        .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
       );
        return services;
    }

    #endregion NewtonSoftJson


}
