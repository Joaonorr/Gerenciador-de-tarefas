using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TarefasFIESC.Models;

namespace TarefasFIESC.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<TarefaModel> Tarefa { get; set; }
    public DbSet<ObservacaoModel> Observacao { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}