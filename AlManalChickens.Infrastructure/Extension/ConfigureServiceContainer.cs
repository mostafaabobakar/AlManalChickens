using AlManalChickens.Domain.Common.Helpers;
using AlManalChickens.Domain.Entities.UserTables;
using AlManalChickens.Persistence;
using AlManalChickens.Services.Api.Contract.Chat;
using AlManalChickens.Services.Api.Contract.General;
using AlManalChickens.Services.Api.Implementation.Chat;
using AlManalChickens.Services.Api.Implementation.General;
using AlManalChickens.Services.DTO;
using AlManalChickens.Services.Models;
using DinkToPdf;
using DinkToPdf.Contracts;
using FirebaseAdmin;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Resources;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Globalization;
using System.Text;
using System.Text.Json;

namespace AlManalChickens.Infrastructure.Extension
{
    public static class ConfigureServiceContainer
    {
        public static void AddDbContextServices(this IServiceCollection services,
             IConfiguration Configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                options.UseLazyLoadingProxies();
            });
        }

        public static void AddSingletonServices(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
        }

        public static void AddLocalizationServices(this IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.Configure<RequestLocalizationOptions>(options =>
            {
                GetLocalizationOptions();
            });
        }


        public static RequestLocalizationOptions GetLocalizationOptions()
        {
            var supportedCultures = new[] { new CultureInfo("ar"), new CultureInfo("en") };
            supportedCultures[0].DateTimeFormat = supportedCultures[1].DateTimeFormat;
            supportedCultures[0].NumberFormat = supportedCultures[1].NumberFormat;

            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(supportedCultures[0]),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                RequestCultureProviders = new List<IRequestCultureProvider>()
                {
                    // Order is important, its in which order they will be evaluated
                    new AcceptLanguageHeaderRequestCultureProvider(),
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider(),
                }
            };

            return localizationOptions;
        }

        public static void TimeOutServices(this IServiceCollection services, IWebHostEnvironment Environment)
        {
            services.AddDataProtection()
                              .SetApplicationName($"my-app-{Environment.EnvironmentName}")
                              .PersistKeysToFileSystem(new DirectoryInfo($@"{Environment.ContentRootPath}\keys"));

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(300);
            });
        }


        public static void AddDefaultIdentityServices(this IServiceCollection services)
        {

            services.AddDefaultIdentity<ApplicationDbUser>(options =>
            {
                // Default Password settings.
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
            }).AddRoles<IdentityRole>().AddDefaultUI().AddEntityFrameworkStores<ApplicationDbContext>();
        }
        public static void AddJwtServices(this IServiceCollection services, IConfiguration Configuration)
        {

            _ = services.AddAuthentication(options =>
            {

            }).AddJwtBearer(options =>
                {

                    options.SaveToken = true;
                    options.RequireHttpsMetadata = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = Configuration["Jwt:Site"],
                        ValidIssuer = Configuration["Jwt:Site"],

                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SigningKey"]))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnChallenge = context =>
                        {
                            // This is where you can customize the response. :)
                            context.HandleResponse();
                            var response = context.Response;
                            response.StatusCode = StatusCodes.Status401Unauthorized;
                            response.ContentType = "application/json";
                            var errorResponse = Result<string>.Fail("Unauthorized", response.StatusCode);
                            return response.WriteAsync(JsonSerializer.Serialize(errorResponse, new JsonSerializerOptions
                            {
                                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                            }));
                        }
                    };
                });

        }
        public static void AddScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IHelper, Helper>();
            services.AddScoped<IChatService, ChatService>();
            services.AddHttpContextAccessor();
        }

        public static void AddTransientServices(this IServiceCollection services)
        {
            services.AddTransient<IUserContext, UserContext>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IHelper, Helper>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfigration>();
            services.AddTransient<IConfigureOptions<SwaggerUIOptions>, SwaggerUIConfiguration>();
            services.AddSwaggerGen();
            services.AddTransient<ILanguageManager, LanguageManager>();
            #region DashBoard
            services.AddTransient<IAppService, AppService>();
            #endregion
        }


        public static void AddCorsServices(this IServiceCollection services)
        {
            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(
            //        builder =>
            //        {
            //            builder.WithOrigins("https://localhost:44306/")
            //            .AllowAnyHeader()
            //            .AllowAnyMethod()
            //            .AllowCredentials();
            //        });
            //});
        }

        public static void AddSessionServices(this IServiceCollection services)
        {
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(1);//You can set Time   
            });
        }

        public static void AddController(this IServiceCollection services)
        {
            services.AddControllers();
        }


        public static void AddMVC(this IServiceCollection services)
        {
            services.AddMvc()
                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
                    //.AddDataAnnotationsLocalization(options =>
                    //{
                    //    options.DataAnnotationLocalizerProvider = (type, factory) =>
                    //        factory.Create(typeof(ModelBindingMessages));
                    //});
        }
        public static void AddFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(ServicesAssembly).Assembly)
                    .AddFluentValidationAutoValidation()
                    .AddFluentValidationClientsideAdapters();
        }

        public static void ScanAllServices(this IServiceCollection services)
        {
            services.Scan
            (
                scan => scan
                    .FromAssemblyOf<ServicesAssembly>()
                    .AddClasses
                    (
                        classes => classes.Where
                        (type =>
                            (type.IsInterface || type.IsClass) && (type.Name.EndsWith("Service") || type.Name.EndsWith("Services"))
                        )
                    )
                    .AsImplementedInterfaces()
                    .WithTransientLifetime()
            );
        }

        public static void AddFireBase(this IServiceCollection services)
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "firebase-file.json")),
            });
        }
    }
}
