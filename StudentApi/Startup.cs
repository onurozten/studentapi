using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Student.Core.Models;
using Student.Core.Services;
using Student.Data;
using Student.Data.Entities;
using Student.Data.Repository;

namespace Student.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);


            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var signingKey = new SymmetricSecurityKey(key);

            services.AddSingleton<AppSettings>(appSettings);


            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {


                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                    //options.Events = new JwtBearerEvents
                    //{
                    //    OnTokenValidated = ctx => {
                    //        //Gerekirse burada gelen token içerisindeki çeþitli bilgilere göre doðrulam yapýlabilir.
                    //        return Task.CompletedTask;
                    //    },
                    //    OnAuthenticationFailed = ctx => {
                    //        Console.WriteLine("Exception:{0}", ctx.Exception.Message);
                    //        return Task.CompletedTask;
                    //    },
                    //    OnMessageReceived = ctx => {
                    //        return Task.CompletedTask;
                    //    }
                    //};
                });

            services.AddAuthorization(auth =>
            {
                auth.DefaultPolicy =
                    new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                        .RequireAuthenticatedUser()
                        .Build();
            });

            // configure dbcontexts
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:DbConnection"]);
            });

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<UserManager<User>>();
            services.AddScoped<SignInManager<User>>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILessonService, LessonService>();

            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<ILessonUserMapRepository, LessonUserMapRepository>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 0;
            });

            services.AddScoped<HttpContextAccessor>();
            services.AddScoped<UserService>();

            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                IdentityModelEventSource.ShowPII = true;
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapRazorPages();
            });

           
        }
    }
}
