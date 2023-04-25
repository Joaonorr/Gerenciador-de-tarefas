using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarefasFIESC.Models;

public class TarefaModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Título é um campo obrigatório")]
    public string Titulo { get; set; }
    
    [Required(ErrorMessage = "Tipo é um campo obrigatório")]
    public string Tipo { get; set; }

    [Required(ErrorMessage = "Situação é um campo obrigatório")]
    public string Situacao { get; set; }

    [Required(ErrorMessage = "Prioridade é um campo obrigatório")]
    public string Prioridade { get; set; }

    [Required(ErrorMessage = "Descrição é um campo obrigatório")]
    public string Descricao { get; set; }

    public string? DescricaoFinal { get; set; }

    public Guid? UsuarioId { get; set; }

    public string? UsuarioNome { get; set; }

    public DateTime DataDeCricacao { get; set; }

    public ICollection<ObservacaoModel>? Observacoes { get; set; }


    public TarefaModel()
    {
        Situacao = "Aberta";
        DataDeCricacao = DateTime.Now.ToUniversalTime();
    }


}
