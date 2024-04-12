namespace SpotiPie.Mappings;

public class TrackDataMappings : Profile
{
    public TrackDataMappings()
    {
        CreateMap<TrackData, TrackDataDto>()
            .ForMember(
                dest => dest.MimeType,
                opts => opts.MapFrom(src => src.MediaType))
            .ReverseMap();
    }
}
