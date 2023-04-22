using Microsoft.Extensions.Configuration;
using TarefasFIESC.Models;
using TarefasFIESC.Repository;
using TarefasFIESC.Seguranca;
using TarefasFIESC.Sessoes;

namespace TarefasFIESC.Helpers;

public class GerenciadorDeSessao
{
    private readonly ISessao _sessao;

    public GerenciadorDeSessao(ISessao sessao)
    {
        _sessao = sessao;            
    }

    public UsuarioModel ResgatarNomeDoUsuario()
    {
        var sessao = _sessao.BuscarSessao();

        if (sessao == null)
        {
            return null;
        }

        var usuario = GerenciarToken.DescrToken(sessao);

        return usuario;
    }
}
