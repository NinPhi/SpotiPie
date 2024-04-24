using Microsoft.Extensions.DependencyInjection;
using SpotiPie.Application.Services;
using System.Reflection;

namespace SpotiPie.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddSingleton<IPasswordManager, PasswordManager>();
        services.AddTransient<IUserService, UserService>();

        services.AddTransient<IArtistService, ArtistService>();
        services.AddTransient<ILyricsService, LyricsService>();
        services.AddTransient<IAlbumService, AlbumService>();
        services.AddTransient<IGenreService, GenreService>();
        services.AddTransient<ITrackService, TrackService>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
