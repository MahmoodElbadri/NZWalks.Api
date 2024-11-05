using AutoMapper;
using NZWalks.Api.Models.Domain;
using NZWalks.Api.Models.DTO;
using NZWalks.Api.Models.DTO.DifficultyDto;
using NZWalks.Api.Models.DTO.Walks;

namespace NZWalks.Api.Mappings;

public class AutoMapperProfiles:Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Region, RegionDto>().ReverseMap();
        CreateMap<Region, RegionAddRequest>().ReverseMap();
        CreateMap<Region,RegionUpdateRequest>().ReverseMap();
        CreateMap<Walks, WalksAddRequest>().ReverseMap();
        CreateMap<Walks, WalkDto>().ReverseMap();
        CreateMap<Difficulty, DifficultyDto>().ReverseMap();
        CreateMap<WalkUpdateRequest, Walks>().ReverseMap();
    }
}
