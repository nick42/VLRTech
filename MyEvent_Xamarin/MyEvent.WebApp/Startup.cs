using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyEvent.WebApp.Data;
using MyEvent.WebApp.Models;
using MyEvent.WebApp.Services;

namespace MyEvent.WebApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            // Note: Actual DB-backed repositories should be added as Scoped
            // Test repositories should probably be added as Singleton, to persist for the lifetime of a run

            // Note: Data population (in current form) doesn't work if the services container is allowed to create the singleton instances.
            // I guess this is because there are actually different singletons per service provider, and the configuration method to add 
            // test data is creating a new service provider. Constructing the instances explicitly fixes this issue (would be a separate 
            // issue if we needed dispose semantics, as that is not called by the services container on external instance add).

            services.AddSingleton<Data.Repositories.IModelDataRepository<Data.Models.Event>>(new Data.Repositories.ModelDataRepository_DataInInstance<Data.Models.Event>());
            services.AddSingleton<Data.Repositories.IModelDataRepository<Data.Models.PlannedActivity>>(new Data.Repositories.ModelDataRepository_DataInInstance<Data.Models.PlannedActivity>());
            services.AddSingleton<Data.Repositories.IModelDataRepository<Data.Models.LocationInfo>>(new Data.Repositories.ModelDataRepository_DataInInstance<Data.Models.LocationInfo>());
            services.AddSingleton<Data.Repositories.IModelDataRepository<Data.Models.AddressInfo>>(new Data.Repositories.ModelDataRepository_DataInInstance<Data.Models.AddressInfo>());
            services.AddSingleton<TestDataPopulation>();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            AddSampleDataToRepositories(services);
        }

        public void AddSampleDataToRepositories(IServiceCollection services)
        {
            var oServiceProvider = services.BuildServiceProvider();
            var oTestDataPopulation = oServiceProvider.GetService<TestDataPopulation>();
            if (oTestDataPopulation != null)
            {
                oTestDataPopulation.PopulateTestData();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
