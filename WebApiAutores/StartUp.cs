using System;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace WebApiAutores
{
    public class StartUp
    {
        public StartUp(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(jsonOption =>
            {
                jsonOption.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });


            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnextion"))
            );

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }


        public void Cofigure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

