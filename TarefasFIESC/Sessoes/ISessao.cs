namespace TarefasFIESC.Sessoes;

public interface ISessao
{
    void CriarSessao(string token);

    void RemoverSessao();

    string BuscarSessao();

    bool ValidarSessao();
}
