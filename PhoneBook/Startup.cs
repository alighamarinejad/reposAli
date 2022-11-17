using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class Startup
    {

        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddControllers();

            services.AddDbContext<Data.DataBaseContext>(options => options
            .UseSqlServer(Configuration.GetConnectionString("MyConnectionStrings")));

            services.AddTransient<Data.IUnitOfWork, Data.UnitOfWork>(sp =>
            {
                Data.Tools.Options options =
                    new Data.Tools.Options
                    {
                        Provider =
                            (Data.Enums.Provider)
                            System.Convert.ToInt32(Configuration.GetSection(key: (Data.Enums.Provider.SqlServer).ToString()).Value),

                        //using Microsoft.EntityFrameworkCore;
                        //ConnectionString =
                        //	Configuration.GetConnectionString().GetSection(key: "MyConnectionString").Value,

                        ConnectionString =
                           Configuration.GetConnectionString("MyConnectionStrings")
                    };

                return new Data.UnitOfWork(options: options);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();


            app.UseEndpoints(endpoits => endpoits.MapControllers());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern:"{controller=home}/{action=index}/{Id?}"
                    
                    );
            });
        }
    }
}
