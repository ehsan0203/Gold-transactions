using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tamrin12shahrivar.Model;
using Tamrin12shahrivar.Model.Dto;
using Tamrin12shahrivar.Repositories.Interface;

namespace Tamrin12shahrivar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGemRepository _repository;
        public GemController(IMapper mapper, IGemRepository repository = null)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var Domain = await _repository.GetAllAsync();
            var Dto = _mapper.Map<List<GemRequestDto>>(Domain);
            return Ok(Dto);

        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var domain = await _repository.GetByIdAsync(id);
            if (domain == null)
            {
                return NotFound();
            }
            var Dto = _mapper.Map<GemRequestDto>(domain);
            return Ok(Dto);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] GemRequestUpdateDto gemdto)
        {
            var domain = _mapper.Map<Gem>(gemdto);
            if (domain == null)
            {
                return BadRequest();
            }
            await _repository.CreateAsync(domain);
            var Dto = _mapper.Map<GemRequestDto>(domain);
            return Ok(Dto);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(Guid Id,[FromBody] GemRequestUpdateDto gemdto)
        {
            var domain = _mapper.Map<Gem>(gemdto);
            if (domain == null)
            {
                return BadRequest();
            }
           domain = await _repository.UpdateAsync(Id,domain);
            var Dto = _mapper.Map<GemRequestDto>(domain);
            return Ok(Dto);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var domain = await _repository.DeleteByAsync(id);
            if (domain == null)
            {
                return NotFound();  
            }
            var dto = _mapper.Map<GemRequestDto>(domain);
            return Ok(dto);
        }

        [HttpGet("Profit")]
        public async Task<IActionResult> Profit()
        {
            return Ok(await _repository.ReportAsync());
        }
    }
}
