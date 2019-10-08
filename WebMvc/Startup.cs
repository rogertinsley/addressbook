using Contacts.Core.Configuration;
using Contacts.Core.Data;
using Contacts.Core.Event;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace WebMvc
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
            // Settings
            services.Configure<CosmosSettings>(Configuration.GetSection("CosmosSettings"));
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<CosmosSettings>>().Value);

            services.AddMediatR(typeof(RegisterMediatr));
            services.AddControllersWithViews();
            services.AddScoped(typeof(IRepository<,>), typeof(CosmosRepository<,>));
            services.AddDbContext<ContactContext>(option =>
            {
                var settings = services.BuildServiceProvider().GetService<IOptions<CosmosSettings>>().Value;
                option.UseCosmos(
                    accountEndpoint: settings.AccountEndpoint,
                    accountKey: settings.AccountKey,
                    databaseName: settings.DatabaseName);
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

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
