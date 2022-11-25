using HotelUygulama.BL.Abstract;
using HotelUygulama.BL.Concrete;
using HotelUygulama.DAL;
using HotelUygulama.DAL.Abstract;
using HotelUygulama.DAL.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelUygulama.API
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
            services.AddControllers();
            services.AddControllersWithViews();
            services.AddSingleton<IHotelService, HotelManager>();
            services.AddSingleton<IHotelRepository, HotelRepository>();
            services.AddSingleton<HotelDbContext>();
            services.AddSwaggerDocument(config=> {
                config.PostProcess = (doc =>
                {
                    doc.Info.Title = "Hotel Rehberi API";
                    doc.Info.Version = "1.1";
                    doc.Info.Contact = new NSwag.OpenApiContact()
                    {
                        Name = "Ali Yılmaz",
                        Url = "http://www.aliyilmaz.com",
                        Email = "a@a.com"
                    };

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
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseOpenApi();
            app.UseSwaggerUi3();//swagger ekranı için

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
