using System.Collections.Generic;
using CRUD.Models;
using CRUD.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace CRUD.Controller
{
  [Route("api/pet")]
  [ApiController]
  public class PetController : ControllerBase
  {
    [HttpPost]
    [Route("GetAllPetByPerson")]
      public async Task<IActionResult> GetAllPetByPerson(
        [FromServices] IPetRepository petRepository,
        [FromBody] Pet body
      )
      {
          IEnumerable<Pet> retorno = await petRepository.GetPetByPerson();
            if (retorno.Count() > 0)
                return Ok(retorno);
            else
                return Ok(new { message = "Nenhum registro encontrado." });
      }

    [HttpPost]
    [Route("GetAllPetByAdoption")]
      public async Task<IActionResult> GetAllPetByAdoption(
        [FromServices] IPetRepository petRepository,
        [FromBody] Pet body
      )
      {
          IEnumerable<Pet> retorno = await petRepository.GetPetByAdoption();
            if (retorno.Count() > 0)
                return Ok(retorno);
            else
                return Ok(new { message = "Nenhum registro encontrado." });
      }

    [HttpPost]
    [Route("SavePet")]
      public async Task<IActionResult> SavePet(
        [FromServices] IPetRepository petRepository,
        [FromBody] Pet body
      )      
      {
        try
        {
          petRepository.SavePet(body.Nome, body.PessoaId , body.Adotado);
          return Ok();
        }
        catch(Exception e)
        {
          return NotFound(new { message = "Nenhum registro encontrado." });
        }
      }
  }
}