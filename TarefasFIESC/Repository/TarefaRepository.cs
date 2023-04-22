using TarefasFIESC.Data;
using TarefasFIESC.Models;

namespace TarefasFIESC.Repository;

public class TarefaRepository : ITarefaRepository
{
    private readonly ApplicationDbContext _context;

    public TarefaRepository(ApplicationDbContext context)
    {
            _context = context;
    }


    public TarefaModel Adicionar(TarefaModel tarefa)
    {
        _context.Tarefa.Add(tarefa);

        _context.SaveChanges();

        return tarefa;
    }


    public List<TarefaModel> BuscarTarefas()
    {
        return _context.Tarefa.ToList();
    }


    public TarefaModel BuscarTarefa(int id)
    {
        var tarefa = _context.Tarefa.FirstOrDefault(t => t.Id == id);

        if (tarefa == null)
        {
            return null;
        }

        return tarefa;
    }


    public TarefaModel EditarTarefa(int id, string descricaoFinal)
    {
        var tarefa = _context.Tarefa.FirstOrDefault(t => t.Id == id);

        if (tarefa == null)
        {
            return null;
        }

        tarefa.DescricaoFinal = descricaoFinal;

        tarefa.Situacao = "Fechada";

        _context.Tarefa.Update(tarefa);

        _context.SaveChanges();

        return tarefa;
    }
}
