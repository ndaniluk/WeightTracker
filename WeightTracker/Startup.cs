using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeightTracker.Data;
using WeightTracker.Entities;

namespace WeightTracker
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
         services.AddDbContext<WeightTrackerContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("WeightTrackerContextConnection")));

         services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<WeightTrackerContext>();

         services.AddControllersWithViews(config =>
         {
            var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            config.Filters.Add(new AuthorizeFilter(policy));
         });
         services.AddRazorPages();
      }

      public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }
         else
         {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
         }
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
            endpoints.MapRazorPages();

            InitRoles(serviceProvider).Wait();
         });
      }

      private async Task InitRoles(IServiceProvider serviceProvider)
      {
         var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
         var roleCheckAdministrator = await roleManager.RoleExistsAsync("Administrator");
         var roleCheckUser = await roleManager.RoleExistsAsync("User");
         if (!roleCheckAdministrator)
         {
            await roleManager.CreateAsync(new IdentityRole("Administrator"));
         }
         if (!roleCheckUser)
         {
            await roleManager.CreateAsync(new IdentityRole("User"));
         }
      }
   }
}
