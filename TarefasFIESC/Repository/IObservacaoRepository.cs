using TarefasFIESC.Models;

namespace TarefasFIESC.Repository;

public interface IObservacaoRepository
{
    ObservacaoModel Adicionar(ObservacaoModel observacao);
    ObservacaoModel Editar(ObservacaoModel model);
    List<ObservacaoModel> BuscarObservacoes(int tarefaId);
}
