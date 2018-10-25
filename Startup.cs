﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TeslaGame.Models;

namespace TeslaGame
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddTransient<IProductRepository, TestProductRepository>();
			services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
			app.UseDeveloperExceptionPage();
			app.UseStatusCodePages();
			app.UseStaticFiles();
			app.UseMvc(routes =>
			{

			});
		}
    }
}
