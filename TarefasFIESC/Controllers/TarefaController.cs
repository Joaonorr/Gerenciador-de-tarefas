using Microsoft.AspNetCore.Mvc;
using TarefasFIESC.Repository;
using TarefasFIESC.Sessoes;

namespace TarefasFIESC.Controllers;

public class TarefaController : Controller
{

    private readonly ITarefaRepository _tarefaRepository;
    private readonly IObservacaoRepository _observacaoRepository;
    private readonly IConfiguration _configuration;
    private readonly ISessao _sessao;

    public TarefaController(ITarefaRepository tarefaRepository,
        IObservacaoRepository observacaoRepository,
        ISessao sessao,
        IConfiguration configuration)
    {
        _tarefaRepository = tarefaRepository;
        _observacaoRepository = observacaoRepository;
        _sessao = sessao;
        _configuration = configuration;
    }
}
