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
    [MinLength(8, ErrorMessage = "A senha deve ter pelo menos 8 caracteres")]
    public string Senha { get; set; }

    [Required(ErrorMessage = "O campo de confirmar senha é obrigatório")]
    [MinLength(8, ErrorMessage = "A senha deve ter pelo menos 8 caracteres")]
    [Compare("Senha", ErrorMessage = "As senhas não coincidem")]
    public string Senha2 { get; set; }
}
