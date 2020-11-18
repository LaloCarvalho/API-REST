using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD.Data;
using CRUD.Models;
using Dapper;

namespace CRUD.Repositories
{
  public class PetRepository : IPetRepository
  {
  private readonly IConnectionFactory conexao;

  public PetRepository(IConnectionFactory connection)
  {
    this.conexao = connection;
  }

    public async Task<IEnumerable<Pet>> GetPetByPerson()
    {
      try
      {
        using (var connection = conexao.Connection())
        {
          connection.Open();
          var query = "Select pe.* from Pet pe inner join Pessoa p ON pe.PessoaId = p.Id";

          return await connection.QueryAsync<Pet>(query);
        }
      }
      catch (Exception ex)
      {
        throw new Exception("Não foi possivel retornar Pets. Erro: " + ex.Message);
      }
    }

    public async Task<IEnumerable<Pet>> GetPetByAdoption()
    {
      try
      {
        using (var connection = conexao.Connection())
        {
          connection.Open();
          var query = "Select pe.* from Pet pe inner join Pessoa p ON pe.PessoaId = p.Id where pe.Adotado = 1 group by p.Nome";

          return await connection.QueryAsync<Pet>(query);
        }
      }
      catch (Exception ex)
      {
        throw new Exception("Não foi possivel retornar Pets. Erro: " + ex.Message);
      }
    }

    public async void SavePet(string Nome, int PessoaId, bool Adotado)
    {
      try
      {
        using (var connection = conexao.Connection())
        {
          connection.Open();
          var query = "insert into Pet(Nome,PessoaId,Adotado) Values (@Nome, @PessoaId, @Adotado)" ;         
          await connection.QueryAsync(query, new { Nome = Nome, PessoaId = PessoaId, Adotado = Adotado });
        }
      }
      catch (Exception ex)
      {
        throw new Exception("Não foi inserir retornar Pets. Erro: " + ex.Message);
      }
    }
  } 
}