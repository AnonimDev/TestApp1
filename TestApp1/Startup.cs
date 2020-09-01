using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TestApp1.Models;
using NLog;

namespace TestApp1
{
    public class Startup
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string databaseConnectionString = Configuration.GetConnectionString("DevConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(databaseConnectionString));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                logger.Info("Адрес: {0}, Метод: {1}, IP: {2}", context.Request.Path, context.Request.Method, context.Connection.RemoteIpAddress);
                await next.Invoke();
                //await context.Response.WriteAsync("Error 404 - Not Found");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            logger.Info("Адрес:");
            /*logger.Info("Адрес: {0}, Метод: {1}, IP: {2}", Request.Path, Request.Method, Connection.RemoteIpAddress);
            */
            
        }
    }
}
