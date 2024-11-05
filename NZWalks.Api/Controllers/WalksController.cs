using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Api.Filters;
using NZWalks.Api.Models.Domain;
using NZWalks.Api.Models.DTO.Walks;
using NZWalks.Api.Repositories;

namespace NZWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            _mapper = mapper;
            _walkRepository = walkRepository;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] WalksAddRequest walksAddRequest)
        {
            var walkModel = _mapper.Map<Walks>(walksAddRequest);
            await _walkRepository.CreateAsync(walks: walkModel);
            var walkDto = _mapper.Map<WalkDto>(walkModel);
            return Ok(walkDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var walks = await _walkRepository.GetAllAsync();
            var walkDtos = _mapper.Map<List<WalkDto>>(walks);
            return Ok(walkDtos);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var walkModel = await _walkRepository.GetByIdAsync(id);
            if (walkModel != null)
            {
                var walkDto = _mapper.Map<WalkDto>(walkModel);
                return Ok(walkDto);
            }

            return NotFound();
        }

        [HttpPut("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromBody] WalkUpdateRequest walksUpdateRequest, [FromRoute] Guid id)
        {
            var walkModel = _mapper.Map<Walks>(walksUpdateRequest);
            walkModel = await _walkRepository.UpdateAsync(walks: walkModel, id: id);
            if (walkModel == null)
            {
                return NotFound();
            }
            else
            {
                var walkDto = _mapper.Map<WalkDto>(walkModel);
                return Ok(walkDto);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedWalkModel = await _walkRepository.DeleteAsync(id: id);
            if (deletedWalkModel == null)
            {
                return NotFound();
            }

            var deletedWalkDto = _mapper.Map<WalkDto>(deletedWalkModel);
            return Ok(deletedWalkDto);
        }
    }
}
