using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD.Data;
using CRUD.Models;
using Dapper;

namespace CRUD.Repositories.Default
{
  public class PessoaRepository : IPessoaRepository
  {
    private readonly IConnectionFactory conexao;


    public PessoaRepository(IConnectionFactory connection)
    {
        this.conexao = connection;
    }

    public async Task<IEnumerable<Pessoa>> GetPersonWithPet()
    {
      try
      {
        using (var connection = conexao.Connection())
        {
          connection.Open();
          var query = "Select p.* from Pessoa p inner join Pet pe ON p.Id = pe.PessoaId";

          return await connection.QueryAsync<Pessoa>(query);
        }
      }
      catch (Exception ex)
      {
        throw new Exception("Não foi possivel retornar Pessoas. Erro: " + ex.Message);
      }
    }

    public async Task<IEnumerable<Pessoa>> GetPersonNoPet()
    {
      try
      {
        using (var connection = conexao.Connection())
        {
          connection.Open();
          var query = "Select p.* from Pessoa p left join Pet pe ON pe.PessoaId = p.Id where p.QtdFilho > 0 and pe.PessoaId is null";

          return await connection.QueryAsync<Pessoa>(query);
        }
      }
      catch (Exception ex)
      {
        throw new Exception("Não foi possivel retornar Pessoas. Erro: " + ex.Message);
      }
    }

    public async void SavePerson(string Nome, int Idade, int QtdFilhos)
    {
      try
      {
        using (var connection = conexao.Connection())
        {
          connection.Open();
          var query = "insert into Pessoa(Nome,Idade,QtdFilho) Values (@Nome, @Idade, @QtdFilhos)" ;         
          await connection.QueryAsync(query, new { Nome = Nome, Idade = Idade, QtdFilhos = QtdFilhos });
        }
      }
      catch (Exception ex)
      {
        throw new Exception("Não foi possivel inserir Pessoas. Erro: " + ex.Message);
      }
    }
  }

}