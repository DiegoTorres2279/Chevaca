using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Services;
using Services.Chevaca;

namespace Board
{
    public class Startup
    {
      
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddHttpContextAccessor();
            services.AddTransient<User_Service>();
            
            if (_env.IsDevelopment())
            {
                services.AddDbContext<ChevacaDB_Context>(e => e.UseSqlServer(_configuration.GetConnectionString("ConnectionString_chboard")));
                services.AddDbContext<ChapiDB_Context>(e => e.UseSqlServer(_configuration.GetConnectionString("ConnectionString_chapi")));
            }else if (_env.IsProduction())
            {
                services.AddDbContext<ChevacaDB_Context>(options => options.UseSqlServer(_configuration.GetConnectionString("ConnectionString_chboard")));
                services.AddDbContext<ChapiDB_Context>(e => e.UseSqlServer(_configuration.GetConnectionString("ConnectionString_chapi")));

            }

            services.AddSession(Options =>
            {
                Options.IdleTimeout = TimeSpan.FromSeconds(3600);
                Options.Cookie.HttpOnly = true;
                Options.Cookie.IsEssential = true;
            });
            //services.AddTransient<IConfiguration>();
            services.AddTransient<logs_Service>();
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    //pattern: "{controller=Home}/{action=Login}/{id?}");
                    pattern: "{controller=Dashboard}/{action=GMaps_inicio}/{id?}");
            });
            
            app.UseExceptionHandler("/page_404");
        }
    }
}
