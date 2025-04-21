using GiveHearth.Dtos;

namespace GiveHearth.Interfaces
{
    public interface IServiceRegister
    {
        Task<List<RegisterDto>> GetAllAsync();
        Task<RegisterDto> GetByIdAsync(int id);
        Task<RegisterDto> CreateAsync(RegisterDto dto);
        Task UpdateAsync(RegisterDto dto, int id);
        Task DeleteAsync(int id);
        Task<List<RegisterDto>> GetAllByCpfAsync(string cpf);
    }
}
