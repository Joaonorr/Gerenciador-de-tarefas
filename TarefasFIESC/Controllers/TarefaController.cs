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

    public IActionResult ListarTarefas(int id)
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
            UsuarioModel = usuario.ResgatarUsuario()
        };

        if (id != 0)
        {
            viewTarefaModel.TarefaCriadaId = id;
        }

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

    public IActionResult DetalharTarefa(int id)
    {
        if (!_sessao.ValidarSessao())
        {
            return RedirectToAction("Entrar", "Login");
        }

        var tarefa = new List<TarefaModel>() { _tarefaRepository.BuscarTarefa(id) };

        var observacoes = _observacaoRepository.BuscarObservacoes(id);

        var usuario = new GerenciadorDeSessao(_sessao);

        var viewTarefaModel = new ViewTarefaModel()
        {
            Tarefas = tarefa,
            Observacoes = observacoes,
            UsuarioModel = usuario.ResgatarUsuario()
        };

        return View(viewTarefaModel);
    }

    public IActionResult FinalizarTarefa(int id)
    {
        if (!_sessao.ValidarSessao())
        {
            return RedirectToAction("Entrar", "Login");
        }

        var tarefa = _tarefaRepository.BuscarTarefa(id);

        return View(tarefa);
    }

    [HttpPost]
    public IActionResult FinalizarTarefa(int id, string descricaoFinal)
    {
        if (!_sessao.ValidarSessao())
        {
            return RedirectToAction("Entrar", "Login");
        }

        _tarefaRepository.FinalizarTarefa(id, descricaoFinal);

        return RedirectToAction("ListarTarefas");
    }

    [HttpPost]
    public IActionResult CriarTarefa(TarefaModel tarefa)
    {
        if (!_sessao.ValidarSessao())
        {
            return RedirectToAction("Entrar", "Login");
        }

        var token = new GerenciadorDeSessao(_sessao);

        var usuario = token.ResgatarUsuario();

        tarefa.UsuarioNome = usuario.Nome;

        tarefa.UsuarioId = usuario.Id;

        var novaTarefa = _tarefaRepository.Adicionar(tarefa);

        return RedirectToAction("ListarTarefas", new { novaTarefa.Id });
    }

    [HttpPost]
    public IActionResult AdicionarObservacao(int tarefaId, string novaObservacao)
    {
        if (!_sessao.ValidarSessao())
        {
            return RedirectToAction("Entrar", "Login");
        }

        ObservacaoModel observacao = new ObservacaoModel()
        {
            TarefaId = tarefaId,
            Descricao = novaObservacao
        };

        var token = new GerenciadorDeSessao(_sessao);

        var usuario = token.ResgatarUsuario();

        observacao.UsuarioNome = usuario.Nome;

        observacao.UsuarioId = usuario.Id;

        _observacaoRepository.Adicionar(observacao);

        return RedirectToAction($"DetalharTarefa", new { id = tarefaId });
    }


    [HttpPost]
    public IActionResult EditarReponsavel(int tarefaId)
    {
        if (!_sessao.ValidarSessao())
        {
            return RedirectToAction("Entrar", "Login");
        }

        var token = new GerenciadorDeSessao(_sessao);

        var usuario = token.ResgatarUsuario();

        _tarefaRepository.EditarReponsavel(tarefaId, usuario);

        return RedirectToAction($"DetalharTarefa", new { id = tarefaId });
    }


}
