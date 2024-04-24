using SpotiPie.Domain.Repositories;
using SpotiPie.Infrastructure.Data.Repositories.Abstractions;

namespace SpotiPie.Infrastructure.Data.Repositories;

public class ArtistRepository(AppDbContext dbContext) : BaseRepository<Artist>(dbContext), IArtistRepository;