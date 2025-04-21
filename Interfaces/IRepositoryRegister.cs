using GiveHearth.Models;

namespace GiveHearth.Interfaces
{
    public interface IRepositoryRegister : IRepositoryBase<Register>
    {
        Task<List<Register>> GetAllByCpfAsync(string cpf);
    }
}
