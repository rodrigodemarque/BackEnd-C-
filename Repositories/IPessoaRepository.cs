using APITeste.Model;

namespace APITeste.Repositories;

public interface IPessoaRepository
{
    Task<List<Pessoa>>ObterTodos();
    Task<Pessoa?> ObterPessoa(int id);
    Task<List<Pessoa>>ObterPessoaByNome(string nome);
    Task<Pessoa>GravarPessoa(Pessoa pessoa);
    Task<Pessoa>AtualizarPessoa(int id, Pessoa pessoa);
    Task<bool>ApagarPessoa(int id);
}
