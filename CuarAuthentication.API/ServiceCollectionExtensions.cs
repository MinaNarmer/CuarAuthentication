using AutoMapper;
using CuarAuthentication.Domain.Context;
using CuarAuthentication.Domain.Identity;
using CuarAuthentication.Domain.IPersistance;
using CuarAuthentication.Domain.Persistance;
using CuarAuthentication.DomainService.Helpers;
using CuarAuthentication.DomainService.IServices;
using CuarAuthentication.DomainService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;


namespace CuarAuthentication.API
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCors(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CORS", corsPolicyBuilder => corsPolicyBuilder.WithOrigins(Configuration["MyConfig:AllowedURL"])
                    // Apply CORS policy for any type of origin  
                    .AllowAnyMethod()
                    // Apply CORS policy for any type of http methods  
                    .AllowAnyHeader()
                    // Apply CORS policy for any headers  
                    .AllowCredentials());
                // Apply CORS policy for all users  
            });
            services.AddCors(options =>
            {
                options.AddPolicy("CORSDev", corsPolicyBuilder => corsPolicyBuilder.WithOrigins(Configuration["MyConfigDev:AllowedURL"])
                    // Apply CORS policy for any type of origin  
                    .AllowAnyMethod()
                    // Apply CORS policy for any type of http methods  
                    .AllowAnyHeader()
                    // Apply CORS policy for any headers  
                    .AllowCredentials());
                // Apply CORS policy for all users  
            });
        }
        public static void AddDbContext(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<CuraAuthDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
        }
        public static void AddIdentity(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 1;
                options.User.RequireUniqueEmail = false;
            });
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<CuraAuthDbContext>()
                .AddDefaultTokenProviders();
        }
        public static void AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration Configuration)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Token:Issuer"],
                        ValidAudience = Configuration["Token:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:Key"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }

        public static void AddMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new GeneralProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IDbFactory, DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();

        }
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(
               options =>
               {
                   options.SwaggerDoc("v1", new OpenApiInfo { Title = "Cura API", Version = "v1" });
                   options.DocInclusionPredicate((docName, description) => true);
                   options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                   {
                       Description =
                       "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                       Name = "Authorization",
                       In = ParameterLocation.Header,
                       Type = SecuritySchemeType.ApiKey,
                       Scheme = "Bearer"
                   });

                   options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                   {
                         {
                            new OpenApiSecurityScheme
                            {
                                 Reference = new OpenApiReference
                                 {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                 },
                                 Scheme = "oauth2",
                                 Name = "Bearer",
                                 In = ParameterLocation.Header,

                            },
                            new List<string>()
                         }
                   });
                   var filePath = Path.Combine(AppContext.BaseDirectory, "CuarAuthentication.API.xml");
                   options.IncludeXmlComments(filePath);
               });
        }

    }
}
