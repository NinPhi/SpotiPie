namespace SpotiPie.Infrastructure.Data.Repositories;

public class GenreRepository(AppDbContext dbContext)
    : BaseRepository<Genre>(dbContext), IGenreRepository;
