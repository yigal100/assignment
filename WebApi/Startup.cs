using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Rewrite;
using WebApi.Data;
using WebApi.Services;

namespace WebApi
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
            services.AddDbContext<DatasetContext>();
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Dataset", Version = "v1" });
            });

            services.AddEntityFrameworkMySql();
            services.AddSingleton(hostingEnvironment.ContentRootFileProvider);
            services.AddScoped<IQueryService, QueryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(b => b.AllowAnyOrigin().Build());
                //app.UseDatabaseErrorPage();
            }
            app.UseDefaultFiles();
            var options = new RewriteOptions().AddRewrite(@"^dataset(/)?.*$", "/index.html", true);
            app.UseRewriter(options);
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
