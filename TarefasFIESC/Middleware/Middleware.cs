using Microsoft.EntityFrameworkCore;
using System;
using TarefasFIESC.Data;

namespace TarefasFIESC.Middleware;

public static class Middleware
{
    public static void ConfiguracaoMiddleware(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        Console.WriteLine("Applying migrations");

        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
        }

        Console.WriteLine("Done");

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        // session enable
        app.UseSession();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Login}/{action=Entrar}/{id?}");

    }
}
