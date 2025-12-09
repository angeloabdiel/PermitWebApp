using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using PermitApplication.Components;
using PermitApplication.Models; // Add this using directive if SqlDataAccess is defined in PermitApplication.Data namespace

namespace PermitApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddControllers();

            builder.Services.AddServerSideBlazor().AddCircuitOptions(options =>
            {
                options.DetailedErrors = true;
            });

            builder.Services.AddSingleton(new PermitsRepository(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Example: Replace 7001 with your actual application port number
            var appBaseUri = new Uri("https://localhost:44395/");

            // Register the HttpClient with the correct base address
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = appBaseUri });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            //app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.UseRouting(); // Enables endpoint routing
            app.UseAntiforgery();
            app.UseAuthorization();

            app.MapControllers(); // Registers and enables controller routing

            app.Run();
        }
    }
}
