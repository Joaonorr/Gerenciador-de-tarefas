using TarefasFIESC.Models;

namespace TarefasFIESC.Repository;

public interface ITarefaRepository
{
    TarefaModel Adicionar(TarefaModel tarefa);

    List<TarefaModel> BuscarTarefas();

    TarefaModel BuscarTarefa(int id);

    TarefaModel FinalizarTarefa(int id, string tarefa);

    TarefaModel EditarReponsavel(int id, UsuarioModel usuarioModel);
}
