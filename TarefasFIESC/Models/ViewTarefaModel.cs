namespace TarefasFIESC.Models;

public class ViewTarefaModel
{
    public List<TarefaModel> Tarefas { get; set; }

    public int TarefaCriadaId { get; set; }
    public List<ObservacaoModel> Observacoes { get; set; }

    public UsuarioModel UsuarioModel { get; set; }
}
