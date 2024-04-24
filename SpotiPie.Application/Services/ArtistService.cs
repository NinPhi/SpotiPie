using SpotiPie.Application.Services.Interfaces.UnitOfWork;
using SpotiPie.Domain.Repositories;

namespace SpotiPie.Application.Services;

public class ArtistService(IArtistRepository artisRepository, IMapper mapper, IUnitOfWork unitOfWork) : IArtistService
{
    private readonly IArtistRepository _artistRepository = artisRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ArtistGetDto?> GetByIdAsync(int id)
    {
        var artist = await _artistRepository.GetByIdAsync(id);

        if (artist is null) return null;

        var artistDto = _mapper.Map<ArtistGetDto>(artist);

        return artistDto;
    }

    public async Task<List<ArtistGetDto>> GetAllAsync()
    {
        var artists = await _artistRepository.GetAllAsync();

        var artistDtos = _mapper.Map<List<ArtistGetDto>>(artists);

        return artistDtos;
    }

    public async Task CreateAsync(ArtistCreateDto artistDto)
    {
        var artist = _mapper.Map<Artist>(artistDto);

        _artistRepository.Add(artist);

        await unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var artist = await _artistRepository.GetByIdAsync(id);

        if (artist is null) return;

        _artistRepository.Remove(artist);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> AddFollowerAsync(int id)
    {
        var artist = await _artistRepository.GetByIdAsync(id);

        if (artist is null) return false;

        artist.Followers++;

        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}
