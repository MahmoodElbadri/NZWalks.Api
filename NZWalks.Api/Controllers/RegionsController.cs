using Microsoft.AspNetCore.Mvc;
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
    public IActionResult Index()
    {
        var regions = _db.Regions.ToList();
        var regionDtos = new List<RegionDto>();
        foreach (Region region in regions)
        {
            regionDtos.Add(new RegionDto()
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            });
        }
        return Ok(regionDtos);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetRegionById(Guid id)
    {
        // var region = _db.Regions.Find(id);
        var region = _db.Regions.Where(tmp => tmp.Id == id).FirstOrDefault();
        if (region == null)
        {
            return NotFound();
        }

        var regionDto = new RegionDto()
        {
            Code = region.Code, Id = region.Id, Name = region.Name, RegionImageUrl = region.RegionImageUrl
        }; 
        return Ok(regionDto);
    }
}
