using Microsoft.EntityFrameworkCore;

using OTA_P01.Data;

internal partial class Program
{
    private static object webApplication;

    private static void Main(string[] args, WebApplicationBuilder builder, object app)
    {
        WebApplicationBuilder webAppBuilder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        webAppBuilder.Services.AddControllersWithViews();
        IServiceCollection serviceCollection = webAppBuilder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(webAppBuilder.Configuration.GetConnectionString("DefaultConnection")));

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
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

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
