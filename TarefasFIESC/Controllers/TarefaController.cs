﻿using Microsoft.AspNetCore.Mvc;
using TarefasFIESC.Helpers;
using TarefasFIESC.Models;
using TarefasFIESC.Repository;
using TarefasFIESC.Sessoes;

namespace TarefasFIESC.Controllers;

public class TarefaController : Controller
{

    private readonly ITarefaRepository _tarefaRepository;

    private readonly IObservacaoRepository _observacaoRepository;

    private readonly IConfiguration _configuration;

    private readonly ISessao _sessao;

    public TarefaController(ITarefaRepository tarefaRepository, IObservacaoRepository observacaoRepository,
        ISessao sessao, IConfiguration configuration)
    {
        _tarefaRepository = tarefaRepository;
        _observacaoRepository = observacaoRepository;
        _sessao = sessao;
        _configuration = configuration;
    }

    public IActionResult ListarTarefas()
    {
        if (!_sessao.ValidarSessao())
        {
            return RedirectToAction("Entrar", "Login");
        }

        var tarefas = _tarefaRepository.BuscarTarefas();

        var usuario = new GerenciadorDeSessao(_sessao);

        var viewTarefaModel = new ViewTarefaModel()
        {
            Tarefas = tarefas,
            UsuarioModel = usuario.ResgatarNomeDoUsuario()
        };

        return View(viewTarefaModel);
    }

    public IActionResult CriarTarefa()
    {
        if (!_sessao.ValidarSessao())
        {
            return RedirectToAction("Entrar", "Login");
        }

        return View();
    }
}
