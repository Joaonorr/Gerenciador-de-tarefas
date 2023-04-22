using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using TarefasFIESC.Models;
using TarefasFIESC.Seguranca;

namespace TarefasFIESC.Sessoes;

public class Sessao : ISessao
{
    private readonly IHttpContextAccessor _httpContext;

    private readonly IConfiguration _configuration;

    public Sessao(IHttpContextAccessor httpContext, IConfiguration configuration)
    {
        _httpContext = httpContext;
        _configuration = configuration;
    }

    public string BuscarSessao()
    {
        string sessao = _httpContext.HttpContext.Session.GetString("tarefasFIESC");

        if (string.IsNullOrEmpty(sessao))
        {
            return null;
        }

        return sessao;
    }

    public void CriarSessao(string token)
    {
        _httpContext.HttpContext.Session.SetString("tarefasFIESC", token);
    }

    public void RemoverSessao()
    {
        _httpContext.HttpContext.Session.Remove("tarefasFIESC");
    }

    public bool ValidarSessao()
    {
        var sessao = BuscarSessao();

        if (String.IsNullOrEmpty(sessao) || !GerenciarToken.VerificarToken(sessao, _configuration))
        {
            return false;
        }

        return true;
    }
}