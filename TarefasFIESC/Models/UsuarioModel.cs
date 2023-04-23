using System.ComponentModel.DataAnnotations;

namespace TarefasFIESC.Models;

public class UsuarioModel
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "O campo Nome é obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O campo Email é obrigatório")]
    [EmailAddress(ErrorMessage = "O formato do email inserido é inválido")]
    public string Email { get; set; }
    [Required(ErrorMessage = "O campo de senha é obrigatório")]
    [MinLength(8)]
    public string Senha { get; set; }

    [Required(ErrorMessage = "O campo de confirmar senha é obrigatório")]
    [MinLength(8)]
    public string Senha2 { get; set; }
}
