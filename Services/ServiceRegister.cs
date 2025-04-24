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
        private readonly IServiceEmail _serviceEmail;

        public ServiceRegister(IRepositoryRegister repositoryRegister, IMapper mapper, IServiceEmail serviceEmail)
        {
            _repositoryRegister = repositoryRegister;
            _mapper = mapper;
            _serviceEmail = serviceEmail;
        }

        public async Task<RegisterDto> CreateAsync(RegisterDto dto)
        {
            var register = _mapper.Map<Register>(dto);
   
            var registerDto = _mapper.Map<RegisterDto>(await _repositoryRegister.CreateAsync(register));

            await _serviceEmail.SendEmailAsync(registerDto.Email, registerDto.RegisterDate);
            return registerDto;
        }

        public async Task DeleteAsync(int id)
        {
            var register = await _repositoryRegister.GetByIdAsync(id);

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
            var register = await _repositoryRegister.GetByIdAsync(id);

            _mapper.Map(dto, register);
            await _repositoryRegister.UpdateAsync(register);

            if (register.Email != dto.Email || register.RegisterDate != dto.RegisterDate)
            {
                await _serviceEmail.SendEmailAsync(register.Email, register.RegisterDate);
            }
        }
    }
}
