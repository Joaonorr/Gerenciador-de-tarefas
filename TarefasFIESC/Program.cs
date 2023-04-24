using TarefasFIESC.Middleware;
using TarefasFIESC.Servicos;

var builder = WebApplication.CreateBuilder(args);

builder.ConfiguracaoServico();

var app = builder.Build();

app.ConfiguracaoMiddleware();

app.Run();
