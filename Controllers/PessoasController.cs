using APITeste.Context;
using APITeste.Model;
using APITeste.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITeste.Controllers;

[ApiController]
[Route("api/pessoa")]
public class PessoasController : ControllerBase
{
 /*   private readonly ApplicationDbContext _context;
    public PessoasController(ApplicationDbContext context)
    {
        _context = context;
    }*/

    private readonly IPessoaRepository _repository;

    public PessoasController(IPessoaRepository repository)
    {
        _repository = repository;
    }


    [HttpGet()]

    public async Task<ActionResult<Pessoa>> ObterTodos()
    {
        //return Ok(await _context.Pessoa.ToListAsync());
        return Ok(await _repository.ObterTodos());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pessoa>> ObterPessoa(int id)
    {
        // var pessoa = await _context.Pessoa.FindAsync(id);
        var pessoa = await _repository.ObterPessoa(id);
        if (pessoa == null)
        {
            return NotFound($"Pessoa com o id: {id} não foi encontrada");
        }

        return Ok(pessoa);
    }

     [HttpGet("{nome:alpha}")]
    public async Task<ActionResult<Pessoa>> ObterPessoaByNome(string nome)
    {
        // var pessoa = await _context.Pessoa.FindAsync(id);
        var pessoa = await _repository.ObterPessoaByNome(nome);
        if (pessoa == null)
        {
            return NotFound($"Pessoa com o nome: {nome} não foi encontrada");
        }

        return Ok(pessoa);
    }

    [HttpPost()]

    public async Task<ActionResult<Pessoa>> GravarPessoa([FromBody] Pessoa model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Os dados para gravar não foram preenchidos");
        }
    /*    _context.Add(model);
        await _context.SaveChangesAsync();
        return Ok(model);*/
        var pessoa = await _repository.GravarPessoa(model);
        return Ok(pessoa);
    }

    [HttpPut("{id:int}")]

    public async Task<ActionResult<Pessoa>> AtualizarPessoa(int id, Pessoa model)
    {
        /*  var pessoa = await _context.Pessoa.FindAsync(id);
          if (pessoa == null)
              return NotFound();
          pessoa.Nome = model.Nome;
          pessoa.Idade = model.Idade;
          pessoa.Sexo = model.Sexo;

          _context.Pessoa.Update(pessoa);
          await _context.SaveChangesAsync();
          return Ok(pessoa);
  */
        var pessoa = await _repository.AtualizarPessoa(id, model);
        if (pessoa == null)
            return NotFound();

        return Ok(pessoa);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> ApagarPessoa(int id)
    {
        /* var pessoa = await _context.Pessoa.FindAsync(id);
         if (pessoa == null)
             return NotFound();

         _context.Pessoa.Remove(pessoa);
         await _context.SaveChangesAsync();
         return Ok();*/

        var apagou = await _repository.ApagarPessoa(id);
        if (!apagou)
            return NotFound();

        return Ok();
    }

}
