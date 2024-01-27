using Application.Commons.Interfaces;
using Application.Commons.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text.Json.Serialization;
using Todo.Api.Common.Services;

namespace Todo.Api;

public static class ConfigureServices
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        SerilogSettings(configuration);
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddControllers().AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });
        services.AddEndpointsApiExplorer();
        services.AddAuthorization();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtSettings(configuration);
        services.AddHttpContextAccessor();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Scheme = "bearer",
                Description = "Please insert JWT token into field"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
        });
            c.MapType<DateOnly>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "date"
            });

        });
        return services;

    }
    public static void SerilogSettings(IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        .MinimumLevel.Information()
        .WriteTo.Console()
        .WriteTo.File("C:\\Users\\HP\\source\\repos\\Todo.Api\\Todo.Api\\Log\\", rollingInterval: RollingInterval.Day)
        .Enrich.FromLogContext()
        .Enrich.WithEnvironmentUserName()
        .Enrich.WithMachineName()
        .CreateLogger();
    }
}
