using SpotiPie.Domain.Repositories;
using SpotiPie.Infrastructure.Data.Repositories.Abstractions;

namespace SpotiPie.Infrastructure.Data.Repositories;

public class GenreRepository(AppDbContext dbContext)
    : BaseRepository<Genre>(dbContext), IGenreRespository;
