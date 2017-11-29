using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using assignment.Models;
using Microsoft.Extensions.FileProviders;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Rewrite;

namespace assignment
{
    public class Startup
    {
        private IHostingEnvironment hostingEnvironment;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            hostingEnvironment = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Dataset>();
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Dataset", Version = "v1" });
            });

            services.AddSingleton(hostingEnvironment.ContentRootFileProvider);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dataset API 1.0");
                c.DocumentTitle("Dataset API 1.0");
                c.RoutePrefix = "documentation";
            });
        }
    }
}
