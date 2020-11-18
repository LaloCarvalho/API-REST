using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD.Models;

namespace CRUD.Repositories
{
    public interface IPetRepository
    {
        Task<IEnumerable<Pet>> GetPetByPerson();
        Task<IEnumerable<Pet>> GetPetByAdoption();
        void SavePet(string Nome, int PessoaId, bool Adotado);
    }
}