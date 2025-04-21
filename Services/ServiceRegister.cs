using AutoMapper;
using GiveHearth.Dtos;
using GiveHearth.Interfaces;
using GiveHearth.Models;

namespace GiveHearth.Services
{
    public class ServiceRegister : IServiceRegister
    {
        private readonly IRepositoryRegister _repositoryRegister;
        private readonly IMapper _mapper;

        public ServiceRegister(IRepositoryRegister repositoryRegister, IMapper mapper)
        {
            _repositoryRegister = repositoryRegister;
            _mapper = mapper;
        }

        public async Task<RegisterDto> CreateAsync(RegisterDto dto)
        {
            var register = _mapper.Map<Register>(dto);
   
            return _mapper.Map<RegisterDto>(await _repositoryRegister.CreateAsync(register));
        }

        public async Task DeleteAsync(int id)
        {
            var register = await _repositoryRegister.GetByIdAsync(id);

            if (register == null) throw new Exception();

            await _repositoryRegister.DeleteAsync(register);
        }

        public async Task<List<RegisterDto>> GetAllAsync()
        {
           return  _mapper.Map<List<RegisterDto>>(await _repositoryRegister.GetAllAsync());
        }

        public async Task<List<RegisterDto>> GetAllByCpfAsync(string cpf)
        {
            return _mapper.Map<List<RegisterDto>>(await _repositoryRegister.GetAllByCpfAsync(cpf));
        }

        public async Task<RegisterDto> GetByIdAsync(int id)
        {
            return _mapper.Map<RegisterDto>(await _repositoryRegister.GetByIdAsync(id));
        }

        public async Task UpdateAsync(RegisterDto dto, int id)
        {
            if (dto.Id != id) throw new Exception();

            var register = await _repositoryRegister.GetByIdAsync(id);

            if(register == null) throw new Exception();

            _mapper.Map(dto, register);
            await _repositoryRegister.UpdateAsync(register);
        }
    }
}
