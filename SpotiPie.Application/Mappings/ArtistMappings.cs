namespace SpotiPie.Application.Mappings;

public class ArtistMappings : Profile
{
    public ArtistMappings()
    {
        CreateMap<Artist, ArtistGetDto>().ReverseMap();
        CreateMap<ArtistCreateDto, Artist>().ReverseMap();
    }
}
