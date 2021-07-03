using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store.Data;
using Store.Repositories.Classes;
using Store.Repositories.Interfaces;

namespace Store
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(mvcOptions => mvcOptions.EnableEndpointRouting = false);

            services.AddDbContext<StoreContext>
                (a => a.UseMySql("server=localhost;user=root;password=Cyber2001;database=Store;",
                new MySqlServerVersion(new Version(8, 0, 18))));

            services.AddTransient<IAddressesRepository, AddressesRepository>();
            services.AddTransient<ICartsItemsRepository, CartsItemsRepository>();
            services.AddTransient<ICartsRepository, CartsRepository>();
            services.AddTransient<ICategoriesRepository, CategoriesRepository>();
            services.AddTransient<IClientsAddressesRepository, ClientsAddressesRepository>();
            services.AddTransient<IClientsEmailsRepository, ClientsEmailsRepository>();
            services.AddTransient<IClientsPhonesNumbersRepository, ClientsPhonesNumbersRepository>();
            services.AddTransient<IClientsRepository, ClientsRepository>();
            services.AddTransient<ICommonProductsLeftoversOnPrimaryWarehouseRepository, CommonProductsLeftoversOnPrimaryWarehouseRepository>();
            services.AddTransient<ILeftoversInStoresRepository,LeftoversInStoresRepository>();
            services.AddTransient<IManufacturersRepository, ManufacturersRepository>();
            services.AddTransient<IOrdersItemsRepository, OrdersItemsRepository>();
            services.AddTransient<IOrdersRepository, OrdersRepository>();
            services.AddTransient<IProductsKindsRepository, ProductsKindsRepository>();
            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddTransient<IStoresRepository, StoresRepository>();
        }

        private IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Products}/{action=Index}/{id?}");
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}
