
namespace SpotiPie.Infrastructure.Data.Repositories;

public class LyricsRepository(AppDbContext dbContext)
    : BaseRepository<Lyrics>(dbContext), ILyricsRepository;
