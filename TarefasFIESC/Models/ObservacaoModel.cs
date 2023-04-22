using System.ComponentModel.DataAnnotations;

namespace TarefasFIESC.Models;

public class ObservacaoModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo de Descrição é obrigatório")]

    public string Descricao { get; set; }

    public DateTime DataCriacao { get; set; }

    public DateTime DataEdicao { get; set; }

    public int TarefaId { get; set; }

    public TarefaModel? Tarefa { get; set; }
    public Guid UsuarioId { get; set; }

    [Required]
    public string UsuarioNome { get; set; }


    public ObservacaoModel()
    {
        DateTime dateTime = DateTime.Now.ToUniversalTime();
        DataCriacao = dateTime;
        DataEdicao = dateTime;
    }

}
