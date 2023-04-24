using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TarefasFIESC.Models;
using Microsoft.Extensions.Configuration;

namespace TarefasFIESC.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<TarefaModel> Tarefa { get; set; }
    public DbSet<ObservacaoModel> Observacao { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
    {
        
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<TarefaModel>()
            .Property(t => t.UsuarioNome)
                .IsRequired()
                .HasColumnName("UsuarioNome");

        builder.Entity<ObservacaoModel>()
            .Property(t => t.UsuarioNome)
                .IsRequired()
                .HasColumnName("UsuarioNome");

    }
}