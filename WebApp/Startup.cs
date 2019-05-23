using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using WebApp.Filters;
using WebApp.Abstract;
using WebApp.Services;

namespace WebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerService, CustomerService>();

            services.AddMvc(options => options.Filters.Add(typeof(ApiExceptionFilterAttribute)))
                    .AddRazorPagesOptions(options => options.Conventions.AddPageRoute("/Customer/Index", ""));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvc(routes => routes.MapRoute(name: "default", template: "{controller=Customer}/{action=Index}/{id?}"));
        }
    }
}
