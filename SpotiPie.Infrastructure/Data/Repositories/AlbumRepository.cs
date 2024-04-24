using SpotiPie.Domain.Repositories;
using SpotiPie.Infrastructure.Data.Repositories.Abstractions;

namespace SpotiPie.Infrastructure.Data.Repositories;

public class AlbumRepository(AppDbContext appDbContext) : BaseRepository<Album>(appDbContext), IAlbumRepository;
