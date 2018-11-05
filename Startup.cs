﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TeslaGame.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace TeslaGame
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
			services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:TeslaGameProducts:ConnectionString"]));
			services.AddTransient<IProductRepository, EFProductRepository>();
			services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddMvc();
			services.AddMemoryCache();
			services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
			app.UseDeveloperExceptionPage();
			app.UseStatusCodePages();
			app.UseStaticFiles();
			app.UseSession();
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: null,
					template: "{category}/Page{productPage}",
					defaults: new { Controller = "Product", action = "List" });
				routes.MapRoute(
					name: null,
					template: "Page{productPage}",
					defaults: new { Controller = "Product", action = "List", producPage = 1 });
				routes.MapRoute(
					name: null,
					template: "{category}",
					defaults: new { Controller = "Product", action = "List", producPage = 1 });
				routes.MapRoute(
					name: null,
					template: "",
					defaults: new { Controller = "Product", action = "List", producPage = 1 });
				routes.MapRoute(
					name: null,
					template: "{controller=Product}/{action=List}/{id?}");
			});
			SeedData.EnsurePopulated(app);
		}
    }
}
