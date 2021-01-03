using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DotNet.Session03
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
            services.AddRazorPages();
            services.AddDbContext<PersonDbContext>(options => options.UseSqlServer("Data Source=.\\MSSQLSERVER2019;Initial Catalog=Practice3;Integrated Security=True"));
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1",
            //      new Info
            //      { Title = "Practice03 API Documentation", Version = "v1.0.0" });
            //});
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            // app.UseSwagger();
            // app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Practice03 API Documentation"); });
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
