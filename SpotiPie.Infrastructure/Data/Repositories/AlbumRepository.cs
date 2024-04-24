namespace SpotiPie.Infrastructure.Data.Repositories;

public class AlbumRepository(AppDbContext dbContext)
    : BaseRepository<Album>(dbContext), IAlbumRepository;