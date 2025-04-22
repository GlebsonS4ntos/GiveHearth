using GiveHearth.Dtos;
using GiveHearth.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GiveHearth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistersController : ControllerBase
    {
        private readonly IServiceRegister _serviceRegister;

        public RegistersController(IServiceRegister serviceRegister)
        {
            _serviceRegister = serviceRegister;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegistersAsync()
        {
            return Ok(await _serviceRegister.GetAllAsync());
        }

        [HttpGet("cpf")]
        public async Task<IActionResult> GetAllRegistersByCpfAsync([FromQuery] string cpf)
        {
            return Ok(await _serviceRegister.GetAllByCpfAsync(cpf));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRegisterByIdAsync([FromRoute] int id)
        {
            var register = await _serviceRegister.GetByIdAsync(id);

            if(register == null) return NotFound();

            return Ok(register);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegisterAsync([FromBody] RegisterDto dto)
        {
            var register = await _serviceRegister.CreateAsync(dto);
            return Created($"register/{register.Id}", register);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateRegisterAsync([FromBody] RegisterDto dto, [FromRoute] int id)
        {
            if(dto.Id != id) return BadRequest("Id in the body and route must be the same.");

            var register = await _serviceRegister.GetByIdAsync(id);

            if (register == null) return NotFound();

            await _serviceRegister.UpdateAsync(dto, id);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRegisterAsync([FromRoute] int id)
        {
            var register = await _serviceRegister.GetByIdAsync(id);

            if (register == null) return NotFound();

            await _serviceRegister.DeleteAsync(id);
            return NoContent();
        }
    }
}
