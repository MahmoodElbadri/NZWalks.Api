using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Data;
using NZWalks.Api.Models.Domain;
using NZWalks.Api.Models.DTO;

namespace NZWalks.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegionsController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public RegionsController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var regions = await _db.Regions.ToListAsync();
        var regionDtos = new List<RegionDto>();
        foreach (Region region in regions)
        {
            regionDtos.Add(new RegionDto()
            {
                Id = region.Id, Code = region.Code, Name = region.Name, RegionImageUrl = region.RegionImageUrl
            });
        }

        return Ok(regionDtos);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetRegionById(Guid id)
    {
        // var region = _db.Regions.Find(id);
        var region = await _db.Regions.Where(tmp => tmp.Id == id).FirstOrDefaultAsync();
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
        await _db.Regions.AddAsync(regionModel);
        await _db.SaveChangesAsync();
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
        var regionModel = await _db.Regions.FirstOrDefaultAsync(tmp => tmp.Id == id);
        if (regionModel == null)
        {
            return NotFound();
        }
        else
        {
            regionModel.RegionImageUrl = regionUpdateRequest.RegionImageUrl;
            regionModel.Code = regionUpdateRequest.Code;
            regionModel.Name = regionUpdateRequest.Name;
            await _db.SaveChangesAsync();
            var region = new RegionDto
            {
                Code = regionModel.Code,
                Id = regionModel.Id,
                Name = regionModel.Name,
                RegionImageUrl = regionModel.RegionImageUrl
            };
            return Ok(region);
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var regionModel = await _db.Regions.FirstOrDefaultAsync(tmp => tmp.Id == id);
        if (regionModel != null)
        {
            _db.Regions.Remove(regionModel);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        return NotFound();
    }
}
