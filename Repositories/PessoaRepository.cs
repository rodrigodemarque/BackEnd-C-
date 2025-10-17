
using APITeste.Context;
using APITeste.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace APITeste.Repositories;

public class PessoaRepository : IPessoaRepository

{
    private readonly ApplicationDbContext _context;
    public PessoaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Pessoa>> ObterTodos()
    {
        return await _context.Pessoas.ToListAsync();
    }

    public async Task<Pessoa?> ObterPessoa(int id)
    {
        return await _context.Pessoas.FindAsync(id);
    }

    public async Task<List<Pessoa>> ObterPessoaByNome(string nome)
    {
        return await _context.Pessoas
         .Where(p => p.Nome.StartsWith(nome))
         .OrderBy(p => p.Nome)
         .ToListAsync(); 
    }


    public async Task<Pessoa> GravarPessoa(Pessoa pessoa)
    {
        _context.Pessoas.Add(pessoa);
        await _context.SaveChangesAsync();
        return pessoa;
    }
    public async Task<Pessoa> AtualizarPessoa(int id, Pessoa model)
    {
        var pessoa = await _context.Pessoas.FindAsync(id);
        if (pessoa == null)
            return null;

        pessoa.Nome = model.Nome;
        pessoa.Salario = model.Salario;
        pessoa.DataNascimento = model.DataNascimento;

        _context.Pessoas.Update(pessoa);
        await _context.SaveChangesAsync();

        return pessoa;
    }


    public async Task<bool> ApagarPessoa(int id)
    {
        var pessoa = await _context.Pessoas.FindAsync(id);
        if (pessoa == null)
            return false;

        _context.Pessoas.Remove(pessoa);
        await _context.SaveChangesAsync();
        return true;
    }
}
