using SAS.BusinessLayer;
using SAS.Data;
using SAS.Interfaces;
using SAS.Mapping;
using SAS.Models;
using SAS.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SAS.DBFirst;

namespace SAS
{
	//Add-Migration 20230306165745_SAS_ -Context ApplicationDbContext
	//Update-Database -Context ApplicationDbContext
	public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environments.Development}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddControllersWithViews().AddRazorRuntimeCompilation();
			// View-Models to Models Mapper
			services.AddAutoMapper(typeof(MappingProfile));
            // Adding Interfaces Services
            services.AddTransient<IArea, DBAreaHandler>();
            services.AddTransient<IState, DBStateHandler>();
            services.AddTransient<IEmail, DBEmailHandler>();
            services.AddTransient<IOveride, DBOverideHandler>();
            services.AddTransient<ISuburb, DBSuburbHandler>();
            services.AddTransient<ISREBoard,DBSREBoardHandler>();
            services.AddTransient<ISREBoardTask,DBSREBoardTaskHandler>();
            services.AddTransient<ISREBoardTaskType,DBSREBoardTaskTypeHandler>();
            services.AddTransient<ISRERep,DBSRERepHandler>();
            services.AddTransient<IGeoAccuracy,DBGeoAccuracyHandler>();
            services.AddTransient<ISRECoordinator,DBSRECoordinatorHandler>();
            services.AddTransient<ISRECoordinatorTaskType,DBSRECoordinatorTaskTypeHandler>();
            services.AddTransient<IChaplain, DBChaplainHandler>();
            services.AddTransient<IChaplainTask, DBChaplainTaskHandler>();
            services.AddTransient<IChaplainTaskType, DBChaplainTaskTypeHandler>();
            services.AddTransient<IChurch, DBChurchHandler>();
            services.AddTransient<ICurrentStatus, DBCurrentStatusHandler>();
            services.AddTransient<ITrip, DBTripHandler>();
            services.AddTransient<IMinister, DBMinisterHandler>();
            services.AddTransient<IMinistry, DBMinistryHandler>();
            services.AddTransient<IMinistryType, DBMinistryTypeHandler>();
            services.AddTransient<IMinisterFraternal, DBMinisterFraternalHandler>();
            services.AddTransient<IMinisterFraternalTask, DBMinisterFraternalTaskHandler>();
            services.AddTransient<IMinisterFraternalTaskType, DBMinisterFraternalTaskTypeHandler>();
            services.AddTransient<ITaskType, DBTaskTypeHandler>();
            services.AddTransient<ITask, DBTaskHandler>();
            services.AddTransient<ISchoolGrade, DBSchoolGradeHandler>();
            services.AddTransient<IHS_SchoolGrade, DBHS_SchoolGradeHandler>();
            services.AddTransient<ISRECoordinatorTask, DBSRECoordinatorTaskHandler>();
            services.AddTransient<ITrip, DBTripHandler>();
            services.AddTransient<IUserAreas, DBUserAreasHandler>();
            services.AddTransient<IPrimarySchool, DBPrimarySchoolHandler>();
            services.AddTransient<IHighSchool, DBHighSchoolHandler>();



            //Get current user id anywhere in the project with ef in c# mvc core
            services.AddHttpContextAccessor();
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<SasContext>(options =>
options.UseSqlServer(
          Configuration.GetConnectionString("DefaultConnection")
         ));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, AppClaimsPrincipalFactory>();
            services.AddScoped<SignInManager<ApplicationUser>, AuditableSignInManager<ApplicationUser>>();

            var mvcBuilder = services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.Configure<CookieAuthenticationOptions>(options =>
            {
                options.LoginPath = new PathString("/Account/Login");
            });

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            services.AddControllersWithViews();
            ////services.AddControllersWithViews().AddRazorRuntimeCompilation();//this will make application lazy and slow to load and function
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStatusCodePagesWithRedirects("~/Home/Error/{0}");

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            //Add middleware here
            app.UseMiddleware<RequestLoggingMiddleware>();


            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            //do not add middleware here (it wont be invoked)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });


            //var logger = loggerFactory.CreateLogger(env.EnvironmentName);
            //app.Use(async (context, next) =>
            //{
            //    await next.Invoke();
            //});

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("ill be executed after the code above!");
            //    Debug.WriteLine("invoke thru await next.Invoke();");
            //});

            // Populate default user admin
            DataSeed.Seed(app.ApplicationServices).Wait();
        }
    }
}
