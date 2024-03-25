using AutoMapper;
using SpotiPie.Contracts;
using SpotiPie.Entities;

namespace SpotiPie.Mappings;

public class ArtistMappings : Profile
{
    public ArtistMappings()
    {
        CreateMap<Artist, ArtistGetDto>().ReverseMap();
        CreateMap<ArtistCreateDto, Artist>().ReverseMap();
    }
}
