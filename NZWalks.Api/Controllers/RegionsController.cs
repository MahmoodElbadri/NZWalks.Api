using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Data;
using NZWalks.Api.Models.Domain;
using NZWalks.Api.Models.DTO;
using NZWalks.Api.Repositories;

namespace NZWalks.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegionsController : ControllerBase
{
    private readonly IRegionRepository _regionRepository;
    private readonly IMapper _mapper;
    public RegionsController(IRegionRepository regionRepository,
        IMapper mapper
        )
    {
        _regionRepository = regionRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var regions = await _regionRepository.GetAllAsync();
        
        var regionDtos = _mapper.Map < List<RegionDto>>(regions);

        return Ok(regionDtos);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetRegionById(Guid id)
    {
        // var region = _db.Regions.Find(id);
        // var region = await _db.Regions.Where(tmp => tmp.Id == id).FirstOrDefaultAsync();
        var region = await _regionRepository.GetByIdAsync(id);
        if (region == null)
        {
            return NotFound();
        }

        var regionDto = new RegionDto
        {
            Code = region.Code, Id = region.Id, Name = region.Name, RegionImageUrl = region.RegionImageUrl
        };
        return Ok(regionDto);
    }

    [HttpPost]
    public async Task<IActionResult> AddRegion([FromBody] RegionAddRequest regionAddRequest)
    {
        var regionModel = new Region
        {
            RegionImageUrl = regionAddRequest.RegionImageUrl,
            Code = regionAddRequest.Code,
            Name = regionAddRequest.Name,
        };
        // await _db.Regions.AddAsync(regionModel);
        // await _db.SaveChangesAsync();
        regionModel = await _regionRepository.CreateAsync(region: regionModel);
        var region = new RegionDto
        {
            Code = regionModel.Code,
            Id = regionModel.Id,
            Name = regionModel.Name,
            RegionImageUrl = regionModel.RegionImageUrl
        };
        return CreatedAtAction(nameof(GetRegionById), new { id = regionModel.Id }, region);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromBody] RegionUpdateRequest regionUpdateRequest, [FromRoute] Guid id)
    {
        var regionModel = new Region
        {
            Id = id,
            Code = regionUpdateRequest.Code,
            Name = regionUpdateRequest.Name,
            RegionImageUrl = regionUpdateRequest.RegionImageUrl
        };
        regionModel = await _regionRepository.UpdateAsync(region: regionModel);
        if (regionModel == null)
        {
            return NotFound();
        }

        var regionDto = new RegionDto()
        {
            Code = regionModel.Code,
            Name = regionModel.Name,
            Id = regionModel.Id,
            RegionImageUrl = regionModel.RegionImageUrl,
        };
        return Ok(regionDto);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var regionModel = await _regionRepository.DeleteAsync(id);
        if (regionModel != null)
        {
            return Ok(regionModel);
        }
        return NotFound();
    }
}
