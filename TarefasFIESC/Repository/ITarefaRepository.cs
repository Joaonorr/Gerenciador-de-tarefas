using TarefasFIESC.Models;

namespace TarefasFIESC.Repository;

public interface ITarefaRepository
{
    TarefaModel Adicionar(TarefaModel tarefa);
    List<TarefaModel> BuscarTarefas();
    TarefaModel BuscarTarefa(int id);
    TarefaModel EditarTarefa(int id, string tarefa);
}
