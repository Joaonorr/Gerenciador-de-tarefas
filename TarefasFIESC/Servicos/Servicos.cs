using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;
using System;
using Microsoft.EntityFrameworkCore;
using TarefasFIESC.Data;
using TarefasFIESC.Repository;

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
    }
}
