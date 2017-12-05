using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace SportsStore
{
    public class Startup
    {
        IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var config = Configuration["Data:SportsStoreProducts:ConnectionStrings"];
            //  config = Configuration["Data:test"];
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(config));

            // Use config here will cause error with Products database, don't know why!!
            var config2 = Configuration["Data:SportsStoreIdentity:ConnectionStrings"];
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(config2));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: null,
                    template:"{category}/Page{page:int}",
                    defaults:new {controller="Product", action="List"}
                        );

                routes.MapRoute(
                    name:null,
                    template:"Page{page:int}",
                    defaults:new {controller="Product", action="List", page=1}
                    );

                routes.MapRoute(
                    name: "pagination",
                    template: "{category}",
                    defaults: new { Controller = "Product", action = "List" , page=1});

                routes.MapRoute(
                    name:null,
                    template:"",
                    defaults:new {controller="Product", action="List", page=1}
                    );

                routes.MapRoute(
                    name: "def",
                    template: "{controller=Product}/{action=List}/{id?}"
                        );
            });
            //    SeedData.EnsurePopulated(app);
            //IdentitySeedData.EnsurePopulated(app);
        }
    }
}
