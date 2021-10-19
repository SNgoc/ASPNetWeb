using DemoAuthorization.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAuthorization
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
            //tạo mã authentication
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
                options.LoginPath = "/Account/Index";
                options.LogoutPath = "/Account/SignOut";
                options.AccessDeniedPath = "/Account/AccessDenied";
            });
            services.AddControllersWithViews();
            //tạo thêm chuỗi kết nối này bên Startup.cs để fix lỗi connect
            var conStr = Configuration.GetConnectionString("DemoLoginConnection");
            services.AddDbContext<DemoLoginContext>(options => options.UseLazyLoadingProxies().UseSqlServer(conStr));
            //Make DemoLogin ready to user with DI (dependcies injection) trong controller
            services.AddTransient<DemoLoginContext>();
            //services.AddSingleton<DemoLoginContext>(); //chỉ add thêm 1 đối tượng, transient nhiều đối tượng
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); //xác thực login, phải dùng đúng UseAuthentication(), nếu dùng UseAuthorization() sẽ bị lỗi @user.Value null bên Welcome.cshtml

            app.UseAuthorization(); //phân quyền (role)

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
