using SpotiPie.Domain.Repositories;
using SpotiPie.Infrastructure.Data.Repositories.Abstractions;

namespace SpotiPie.Infrastructure.Data.Repositories;

public class LyricsRepository(AppDbContext dbContext) : BaseRepository<Lyrics>(dbContext), ILyricsRepository;