using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TarefasFIESC.Models;
using TarefasFIESC.Seguranca;
using TarefasFIESC.Sessoes;

namespace TarefasFIESC.Controllers;

public class LoginController : Controller
{
    public readonly UserManager<IdentityUser> _userManager;

    public readonly IConfiguration _configuration;

    public readonly ISessao _sessao;

    public LoginController(UserManager<IdentityUser> userManager, IConfiguration configuration, ISessao sessao)
    {
        _userManager = userManager;
        _configuration = configuration;
        _sessao = sessao;
    }

    public IActionResult Entrar()
    {
        if (_sessao.ValidarSessao())
        {
            return RedirectToAction("ListarTarefas", "Tarefa");
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Entrar(UsuarioModel usuarioModel)
    {
        usuarioModel.Senha2 = usuarioModel.Senha;

        if (!ModelState.IsValid)
        {
            return View(usuarioModel);
        }

        if (_sessao.ValidarSessao())
        {
            return RedirectToAction("ListarTarefas", "Tarefa");
        }

        var usuario = _userManager.FindByEmailAsync(usuarioModel.Email).Result;

        if (usuario != null)
        {
            var token = GerenciarToken.GerarToken(usuario, _userManager, _configuration);

            _sessao.CriarSessao(token);

            return RedirectToAction("ListarTarefas", "Tarefa");
        }

        return View();
    }

    public IActionResult CriarConta()
    {
        if (_sessao.ValidarSessao())
        {
            return RedirectToAction("ListarTarefas", "Tarefa");
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CriarConta(UsuarioModel usuarioModel)
    {
        if (!ModelState.IsValid)
        {
            return View(usuarioModel);
        }

        var usuarioIdentity = new IdentityUser
        {
            UserName = usuarioModel.Email,
            Email = usuarioModel.Email
        };

        var userClaims = new List<Claim>()
        {
            new Claim("Nome", usuarioModel.Nome)
        };

        await _userManager.CreateAsync(usuarioIdentity, usuarioModel.Senha);

        await _userManager.AddClaimsAsync(usuarioIdentity, userClaims);

        return RedirectToAction("entrar");

    }
    public IActionResult Sair()
    {
        _sessao.RemoverSessao();

        return View("Entrar");
    }
}
