using Microsoft.EntityFrameworkCore;
using SimulationV2.Database;
using SimulationV2.Database.Repositories;

namespace SimulationV2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services
            .AddControllersWithViews()
            .AddRazorRuntimeCompilation();
        builder.Services.AddRazorPages();

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<TeacherRepository>();

        var app = builder.Build();

        app.UseStaticFiles();
        app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=AdminDashboard}/{action=Index}/{id?}");

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
