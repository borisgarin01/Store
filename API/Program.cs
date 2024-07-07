using DataAccess.Migrations;
using FluentMigrator.Runner;

namespace API;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        builder.Services.AddSwaggerGen();

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
             .WithGlobalConnectionString(options => builder.Configuration.GetConnectionString("DefaultConnection"))
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

        app.Run();
    }
}