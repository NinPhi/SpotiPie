using SpotiPie.Application.Services.Interfaces.UnitOfWork;
using SpotiPie.Domain.Repositories;

namespace SpotiPie.Application.Services;

public class ArtistService(
    IArtistRepository albumRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IArtistService
{
    public async Task<ArtistGetDto?> GetByIdAsync(int id)
    {
        var artist = await albumRepository.GetByIdAsync(id);

        if (artist is null) return null;

        var artistDto = mapper.Map<ArtistGetDto>(artist);

        return artistDto;
    }

    public async Task<List<ArtistGetDto>> GetAllAsync()
    {
        var artists = await albumRepository.GetAllAsync();

        var artistDtos = mapper.Map<List<ArtistGetDto>>(artists);

        return artistDtos;
    }

    public async Task CreateAsync(ArtistCreateDto artistDto)
    {
        var artist = mapper.Map<Artist>(artistDto);

        albumRepository.Add(artist);

        await unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var artist = await albumRepository.GetByIdAsync(id);

        if (artist is null) return;

        albumRepository.Remove(artist);

        //EntityEntry artistEntry = _dbContext.Entry(artist);
        //artistEntry.State = EntityState.Deleted;

        await unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> AddFollowerAsync(int id)
    {
        await albumRepository.AddFollowerAsync(id);

        await unitOfWork.SaveChangesAsync();

        return true;
    }
}
