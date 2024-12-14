using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Shcool.Data.Entity.Identity;
using Shcool.Data.Helper;
using Shcool.Infrustructure.Application_Data;
using System.Text;

namespace Shcool.Infrustructure
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddServicesRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<User, IdentityRole>(options =>
               {
                   // Password settings.
                   options.Password.RequireDigit = true;
                   options.Password.RequireLowercase = true;
                   options.Password.RequireNonAlphanumeric = true;
                   options.Password.RequireUppercase = true;
                   options.Password.RequiredLength = 6;
                   options.Password.RequiredUniqueChars = 1;

                   // Lockout settings.
                   options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                   options.Lockout.MaxFailedAccessAttempts = 5;
                   options.Lockout.AllowedForNewUsers = true;

                   // User settings.
                   options.User.AllowedUserNameCharacters =
                   "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                   options.User.RequireUniqueEmail = true;
               }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


            var jwtsettings = new JwtSettings();
            configuration.GetSection(nameof(jwtsettings)).Bind(jwtsettings);
            services.AddSingleton(jwtsettings);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = jwtsettings.ValidateIssure,
                    ValidIssuers = new[] { jwtsettings.issure },
                    ValidateIssuerSigningKey = jwtsettings.ValidateIssureSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtsettings.secret)),
                    ValidAudience = jwtsettings.audience,
                    ValidateAudience = jwtsettings.ValidateAudience,
                    ValidateLifetime = jwtsettings.ValidateLifetime
                };


            });


            //Swagger Gn
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "School Project", Version = "v1" });
                c.EnableAnnotations();

                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
            {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            Array.Empty<string>()
            }
           });
            });
            //bind send email
            var emailSettings = new emailSettings();
            configuration.GetSection(nameof(emailSettings)).Bind(emailSettings);
            services.AddSingleton(emailSettings);

            services.AddAuthorization(option =>
            {

                option.AddPolicy("CreateStudent", policy =>
                {
                    policy.RequireClaim("Create Studend", "True");
                }
            );

            });

            return services;
        }
    }
}
