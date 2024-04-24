using SpotiPie.Entities.Contracts;

namespace SpotiPie.Application.Mappings;

public class TrackMappings : Profile
{
    public TrackMappings()
    {
        CreateMap<Track, TrackGetDto>();
    }
}
