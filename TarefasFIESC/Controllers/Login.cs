using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TarefasFIESC.Models;
using TarefasFIESC.Seguranca;
using TarefasFIESC.Sessoes;

namespace TarefasFIESC.Controllers;

public class Login : Controller
{
    public readonly UserManager<IdentityUser> _userManager;

    public readonly IConfiguration _configuration;

    public readonly ISessao _sessao;

    public Login(UserManager<IdentityUser> userManager, IConfiguration configuration, ISessao sessao)
    {
        _userManager = userManager;
        _configuration = configuration;
        _sessao = sessao;
    }

    public IActionResult Entrar()
    {
        var sessao = _sessao.BuscarSessao();

        if (!string.IsNullOrEmpty(sessao) && GerenciarToken.VerificarToken(sessao, _configuration))
        {
            return RedirectToAction("ListarTarefas", "Tarefa");
        }

        return View();
    }

    [HttpPost]
    public IActionResult Entrar(UsuarioModel usuarioModel)
    {
        var sessao = _sessao.BuscarSessao();

        if (!string.IsNullOrEmpty(sessao) && GerenciarToken.VerificarToken(sessao, _configuration))
        {
            return RedirectToAction("ListarTarefas", "Tarefa");
        }

        var usuario = _userManager.FindByEmailAsync(usuarioModel.Email).Result;

        if (usuario != null)
        {
            var token = GerenciarToken.GerarToken(usuario.Email, _userManager, _configuration);

            _sessao.CriarSessao(token);

            return RedirectToAction("ListarTarefas", "Tarefa");
        }

        return View();
    }

    public IActionResult CriarConta()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CriarConta(UsuarioModel usuario)
    {
        var usuarioIdentity = new IdentityUser
        {
            UserName = usuario.Email,
            Email = usuario.Email
        };

        var userClaims = new List<Claim>()
        {
            new Claim("Nome", usuario.Nome)
        };

        _userManager.CreateAsync(usuarioIdentity, usuario.Senha);

        _userManager.AddClaimsAsync(usuarioIdentity, userClaims);


        var token = GerenciarToken.GerarToken(usuario.Email, _userManager, _configuration);

        _sessao.CriarSessao(token);

        return RedirectToAction("Tarefa", "ListarTarefas");

    }
    public IActionResult Sair()
    {
        _sessao.RemoverSessao();

        return View("Entrar");
    }
}
