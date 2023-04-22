using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TarefasFIESC.Data;
using TarefasFIESC.Repository;
using TarefasFIESC.Sessoes;

namespace TarefasFIESC.Servicos;

public static class Servicos
{
    public static void ConfiguracaoServico(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // DataBase
        var pgsqlConnection = builder.Configuration["DbContextSettings:ConnectionString"];

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(pgsqlConnection));

        // Repository
        builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();

        builder.Services.AddScoped<IObservacaoRepository, ObservacaoRepository>();

        // Security and User
        builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 8;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireDigit = false;
        }).AddEntityFrameworkStores<ApplicationDbContext>();

        builder.Services.AddScoped<ISessao, Sessao>();

        builder.Services.AddSession(o =>
        {
            o.Cookie.HttpOnly = true;
            o.Cookie.IsEssential = true;
        });
    }
}
