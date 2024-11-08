using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Api.Filters;
using NZWalks.Api.Models.Domain;
using NZWalks.Api.Models.DTO;
using NZWalks.Api.Repositories;

namespace NZWalks.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RegionsController : ControllerBase
{
    private readonly IRegionRepository _regionRepository;
    private readonly IMapper _mapper;

    public RegionsController(IRegionRepository regionRepository, IMapper mapper)
    {
        _regionRepository = regionRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var regions = await _regionRepository.GetAllAsync();

        var regionDtos = _mapper.Map<List<RegionDto>>(regions);

        return Ok(regionDtos);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetRegionById(Guid id)
    {
        var region = await _regionRepository.GetByIdAsync(id);
        if (region == null)
        {
            return NotFound();
        }

        var regionDto = _mapper.Map<RegionDto>(region);
        return Ok(regionDto);
    }

    [HttpPost]
    [ValidateModel]
    public async Task<IActionResult> AddRegion([FromBody] RegionAddRequest regionAddRequest)
    {
        var regionModel = _mapper.Map<Region>(regionAddRequest);

        regionModel = await _regionRepository.CreateAsync(region: regionModel);

        var regionDto = _mapper.Map<RegionDto>(regionModel);
        return CreatedAtAction(nameof(GetRegionById), new { id = regionModel.Id }, regionDto);
    }

    [HttpPut("{id:guid}")]
    [ValidateModel]
    public async Task<IActionResult> Update([FromBody] RegionUpdateRequest regionUpdateRequest, [FromRoute] Guid id)
    {
            var regionModel = _mapper.Map<Region>(regionUpdateRequest);
            regionModel = await _regionRepository.UpdateAsync(region: regionModel, id);
            if (regionModel == null)
            {
                return NotFound();
            }

            var regionDto = _mapper.Map<RegionDto>(regionModel);
            return Ok(regionDto);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var regionModel = await _regionRepository.DeleteAsync(id);

        if (regionModel != null)
        {
            var regionDto = _mapper.Map<RegionDto>(regionModel);
            return Ok(regionDto);
        }

        return NotFound();
    }
}
