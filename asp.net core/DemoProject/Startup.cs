using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DemoProject.Data.Db;
using DemoProject.Data.Managers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using DemoProject.Controllers;

namespace DemoProject.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MainConnection")));

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            //{
            //    options.RequireHttpsMetadata = true;
            //    options.SaveToken = true;
            //});

            services.AddTransient<ProductController>();

            services.AddTransient<ProductManager>();


            //services.AddCors();
            services.AddMvc();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //app.UseCookiePolicy(new CookiePolicyOptions
            //{
            //    MinimumSameSitePolicy = SameSiteMode.Strict,
            //    HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,
            //    Secure = CookieSecurePolicy.Always
            //});

            //app.UseCors(x => x
            //.AllowAnyHeader()
            //.AllowAnyMethod()
            //.AllowAnyOrigin());

            //app.Use(async (context, options) =>
            //{


            //    var token = context.Request.Cookies[".AspNetCore.Application.Id"];
            //    if (!string.IsNullOrEmpty(token))
            //        context.Request.Headers.Add("Authorization", "Baerer" + token);
            //});

            app.UseMvc();
        }
    }
}
