using FluentMigrator.Runner;
using Migrations.Migrations;
using Repositories.Concrete;
using Repositories.Interfaces.Derived;

namespace API;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

        builder.Services.AddSwaggerGen();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        var serviceProvider = new ServiceCollection()
     // Logging is the replacement for the old IAnnouncer
     .AddLogging(lb => lb.AddFluentMigratorConsole())
     // Registration of all FluentMigrator-specific services
     .AddFluentMigratorCore()
     // Configure the runner
     .ConfigureRunner(
         b => b
             // Use SQLite
             .AddPostgres()
             .ConfigureGlobalProcessorOptions(opt =>
             {
                 opt.ProviderSwitches = "Force Quote=false";
             })
             // The SQLite connection string
             .WithGlobalConnectionString(options => connectionString)
             // Specify the assembly with the migrations
             .WithMigrationsIn(typeof(CreateProductsTableMigration).Assembly))
     .BuildServiceProvider();

        // Put the database update into a scope to ensure
        // that all resources will be disposed.
        using (var scope = serviceProvider.CreateScope())
        {
            // Instantiate the runner
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            runner.ListMigrations();
            // Execute the migrations
            runner.MigrateUp();
        }

        builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>(options => new CategoriesRepository(connectionString));

        builder.Services.AddScoped<IManufacturersRepository, ManufacturersRepository>(options => new ManufacturersRepository(connectionString));

        builder.Services.AddScoped<IProductsRepository, ProductsRepository>(options => new ProductsRepository(connectionString));

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
        else
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapDefaultControllerRoute();

        app.UseMvcWithDefaultRoute();

        app.Run();
    }
}