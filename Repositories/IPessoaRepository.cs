using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD.Models;

namespace CRUD.Repositories
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<Pessoa>> GetPersonWithPet();
        Task<IEnumerable<Pessoa>> GetPersonNoPet();
        void SavePerson(string Nome, int Idade, int QtdFilhos);
    }
}