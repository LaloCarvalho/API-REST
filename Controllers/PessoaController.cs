using System.Collections.Generic;
using CRUD.Models;
using CRUD.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace CRUD.Controller
{
  [Route("api/pessoa")]
  [ApiController]
  public class PessoaController : ControllerBase
  {
    [HttpPost]
    [Route("GetAllPersonWithPet")]
      public async Task<IActionResult> GetAllPersonWithPet(
        [FromServices] IPessoaRepository pessoaRepository,
        [FromBody] Pessoa body
      )
      {
          IEnumerable<Pessoa> retorno = await pessoaRepository.GetPersonWithPet();
            if (retorno.Count() > 0)
                return Ok(retorno);
            else
                return Ok(new { message = "Nenhum registro encontrado." });
      }

    [HttpPost]
    [Route("GetAllPersonNoPet")]
      public async Task<IActionResult> GetAllPersonNoPet(
        [FromServices] IPessoaRepository pessoaRepository,
        [FromBody] Pessoa body
      )
      {
          IEnumerable<Pessoa> retorno = await pessoaRepository.GetPersonNoPet();
            if (retorno.Count() > 0)
                return Ok(retorno);
            else
                return Ok(new { message = "Nenhum registro encontrado." });
      }

    [HttpPost]
    [Route("SavePerson")]
      public async Task<IActionResult> SavePerson(
        [FromServices] IPessoaRepository pessoaRepository,
        [FromBody] Pessoa body
      )      
      {
        try
        {
          pessoaRepository.SavePerson(body.Nome, body.Idade, body.QtdFilho);
          return Ok();
        }
        catch(Exception e)
        {
          return NotFound(new { message = "Nenhum registro encontrado." });
        }
      }
  }
}