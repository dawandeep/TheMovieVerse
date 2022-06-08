using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheMovieVerse.AutoMapper;
using TheMovieVerse.DB;
using TheMovieVerse.DB.Interface;
using TheMovieVerse.Services.Implementation;
using TheMovieVerse.Services.Interface;

namespace TheMovieVerse
{
    public class Startup
    {
        public Startup(IConfiguration configuration  )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AppProfile));
            services.AddControllers();  
            services.AddControllersWithViews();
            services.AddLamar(new ApplicationRegistry());
            services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(this.Configuration.GetConnectionString("DatabaseConnection")));
            //services.AddScoped<IMovieService, MovieService>();
            services.AddSwaggerGen();
            services.AddSwaggerGen(swag =>
            {
                swag.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TheMovieVerse Service",
                    Version = "v1"
                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
            app.UseSwagger();
            app.UseSwaggerUI(x => x.SwaggerEndpoint("v1/swagger.json", "TheMovieVerse Service"));
        }
    }
}
