using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnaliseVendas.Repository;
using AnaliseVendas.Service;
using AnaliseVendasApplication.Implementation;
using AnaliseVendasApplication.Interface;
using AnaliseVendasRepository.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AnaliseVendasAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            this.ConfigureIOC(services);
            services.AddHostedService<SalesHostedService>();
           
        }

        private void ConfigureIOC(IServiceCollection services)
        {
            services.AddScoped<ISalesApplication, SalesApplication>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            //services.AddScoped<ISalesHostedService, SalesHostedService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
