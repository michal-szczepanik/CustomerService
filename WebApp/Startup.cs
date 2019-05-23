using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using WebApp.Filters;
using WebApp.Abstract;
using WebApp.Services;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebApp
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
            services.AddDbContext<CustomerServiceContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("CustomerServiceDb")));

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerService, CustomerService>();

            services.AddMvc(options => options.Filters.Add(typeof(ApiExceptionFilterAttribute)))
                    .AddRazorPagesOptions(options => options.Conventions.AddPageRoute("/Customer/Index", ""));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<CustomerServiceContext>();
                context.Database.EnsureCreated();
            }

            app.UseStaticFiles();
            app.UseMvc(routes => routes.MapRoute(name: "default", template: "{controller=Customer}/{action=Index}/{id?}"));
        }
    }
}
