using BasseinProekta.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasseinProekta
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BasseinContext>(options => options.UseSqlServer(connection));
             

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));

            services.AddIdentity<User, IdentityRole>(options => {
                options.Password.RequiredLength = 3;   // ìèíèìàëüíàÿ äëèíà
                options.Password.RequireNonAlphanumeric = false;   // òðåáóþòñÿ ëè íå àëôàâèòíî-öèôðîâûå ñèìâîëû
                options.Password.RequireLowercase = false; // òðåáóþòñÿ ëè ñèìâîëû â íèæíåì ðåãèñòðå
                options.Password.RequireUppercase = false; // òðåáóþòñÿ ëè ñèìâîëû â âåðõíåì ðåãèñòðå
                options.Password.RequireDigit = false; // òðåáóþòñÿ ëè öèôðû
                options.SignIn.RequireConfirmedAccount = false; //òðåáóþòñÿ ïîäòâåðæäåíèå email
            }).AddEntityFrameworkStores<ApplicationContext>();

            services.AddControllersWithViews();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            env.EnvironmentName = "Production";

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStatusCodePagesWithRedirects("/Home/Error");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
