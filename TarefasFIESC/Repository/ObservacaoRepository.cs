using Microsoft.EntityFrameworkCore;
using TarefasFIESC.Data;
using TarefasFIESC.Models;

namespace TarefasFIESC.Repository;

public class ObservacaoRepository : IObservacaoRepository
{
    private readonly ApplicationDbContext _context;

    public ObservacaoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public ObservacaoModel Adicionar(ObservacaoModel observacao)
    {
        TarefaModel tarefa = _context.Tarefa.FirstOrDefault(t => t.Id == observacao.TarefaId);

        if (tarefa == null)
        {
            return null;
        }

        _context.Observacao.Add(observacao);

        _context.SaveChanges();

        return observacao;
    }

    public ObservacaoModel Editar(ObservacaoModel observacao)
    {
        _context.Observacao.Update(observacao);

        _context.SaveChanges();

        return observacao;
    }

    public List<ObservacaoModel> BuscarObservacoes(int tarefaId)
    {
        List< ObservacaoModel> observacoes = _context.Observacao
            .Where(o => o.TarefaId == tarefaId)
            .OrderBy(o => o.DataCriacao)
            .ToList();

        return observacoes;
    }
}
