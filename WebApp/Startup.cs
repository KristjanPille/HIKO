using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BLL.App;
using BLL.App.DTO.Identity;
using Contracts.BLL.App;
using Contracts.DAL.App;
using DAL.App.EF;
using DAL.App.EF.Helpers;
using ee.itcollege.carwash.kristjan.Contracts.DAL.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using WebApp.Helpers;
using AppRole = Domain.App.Identity.AppRole;
using AppUser = Domain.App.Identity.AppUser;

namespace WebApp
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
            services.AddDbContext<AppDbContext>(options => 
                options.UseMySql(Configuration.GetConnectionString("SqlServerConnection")
                    , options => options.EnableRetryOnFailure()));

            // add as a scoped dependency
            services.AddScoped<IUserNameProvider, UserNameProvider>();
            services.AddScoped<IAppUnitOfWork, AppUnitOfOfWork>();
            services.AddScoped<IAppBLL, AppBLL>();


            services.AddIdentity<Domain.App.Identity.AppUser, Domain.App.Identity.AppRole>(options =>
                    options.SignIn.RequireConfirmedAccount = false)
                .AddDefaultUI()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();


            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddHttpContextAccessor();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsAllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                    });
            });
            
            // =============== JWT support ===============
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            services
                .AddAuthentication()
                .AddCookie(options => { options.SlidingExpiration = true; })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["JWT:Issuer"],
                        ValidAudience = Configuration["JWT:Issuer"],
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SigningKey"])),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                });
            

            services.AddApiVersioning(options => { options.ReportApiVersions = true; });

            services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen();
        }
        
        // public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider, RoleManager<IdentityRole> roleManager)
        /// <summary>
        ///   This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="provider"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            UpdateDatabase(app, env, Configuration);

            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            app.UseRequestLocalization(options: app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value);
            
            app.UseStaticFiles();

            app.UseCors("CorsAllowAll");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "area",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                
                endpoints.MapRazorPages();
            });
        }
        
        private static void UpdateDatabase(IApplicationBuilder app, IWebHostEnvironment env,
            IConfiguration configuration)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
            using var userManager = serviceScope.ServiceProvider.GetService<UserManager<AppUser>>();
            using var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<AppRole>>();
            var logger = serviceScope.ServiceProvider.GetService<ILogger<Startup>>();

            if (configuration.GetValue<bool>("DataInitialization:DropDatabase"))
            {
                logger.LogInformation("DropDatabase");
                DataInitializers.DeleteDatabase(context);
            }

            if (configuration.GetValue<bool>("DataInitialization:MigrateDatabase"))
            {
                logger.LogInformation("MigrateDatabase");
                DataInitializers.MigrateDatabase(context);
            }

            if (configuration.GetValue<bool>("DataInitialization:SeedIdentity"))
            {
                logger.LogInformation("SeedIdentity");
                DataInitializers.SeedIdentity(userManager, roleManager);
            }

            if (configuration.GetValue<bool>("DataInitialization:SeedData"))
            {
                logger.LogInformation("SeedData");
                DataInitializers.SeedData(context);
            }
        }
    }
}