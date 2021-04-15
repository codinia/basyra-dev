using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureADB2C.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Cache;
using AccommodationAPI.Identity;
using System.Data;
using Repository.Provider;
using Services.Interfaces;
using Services.Implementations;
using Repository.Interfaces;
using Repository.Implementations;

namespace AccommodationAPI
{
    public class Startup
    {
        #region Private Members
        private const string _appSettingKey = "AppSettings";
        private const string _connectionStringName = "AccommodationEntities";
        #endregion
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddAuthentication(AzureADB2CDefaults.BearerAuthenticationScheme)
                .AddAzureADB2CBearer(options => Configuration.Bind("AzureAdB2C", options));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMemoryCache();

            this._RegisterApplicationServices(services);
            this._RegisterRepositories(services);
            this._RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
        #region Private Methods
        private void _RegisterApplicationServices(IServiceCollection services)
        {
            #region Identity
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString(_connectionStringName)));
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<DatabaseContext>()
            .AddDefaultTokenProviders();
            #endregion

            #region AppSettings
            services.AddOptions<AppSettings>();
            services.Configure<AppSettings>(Configuration.GetSection(_appSettingKey));
            #endregion

            #region Authentication Services
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.SaveToken = true;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = Configuration.GetSection(_appSettingKey).Get<AppSettings>().JwtIssuer,
                            ValidAudience = Configuration.GetSection(_appSettingKey).Get<AppSettings>().JwtIssuer,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection(_appSettingKey).Get<AppSettings>().JwtKey)),
                            ClockSkew = TimeSpan.Zero
                        };
                    });
            services.AddAuthorization(authorization =>
            {
                authorization.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
            });
            #endregion

            #region HttpContextAccessor (Session)
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion                  
        }

        private void _RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IDbConnection, MSSQL>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IItemRepository, ItemRepository>();
        }

        private void _RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IItemService, ItemService>();
        }

        private void _RegisterComponents(IServiceCollection services)
        {

        }

        private void _RegisterSingleInstances(IServiceCollection services)
        {
            //services.AddSingleton<ILogging, Logging>();
        }
        #endregion
    }
}
