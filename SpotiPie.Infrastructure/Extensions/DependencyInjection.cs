using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpotiPie.Application.Services.Interfaces.UnitOfWork;
using SpotiPie.Infrastructure.Data;
using SpotiPie.Infrastructure.Data.Repositories;

namespace SpotiPie.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString(nameof(AppDbContext))));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IAlbumRepository, AlbumRepository>();
        services.AddScoped<IArtistRepository, ArtistRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<ILyricsRepository, LyricsRepository>();
        services.AddScoped<ITrackRepository, TrackRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
