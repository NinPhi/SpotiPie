using Microsoft.EntityFrameworkCore;
using SpotiPie.Contracts;
using SpotiPie.Data;
using SpotiPie.Entities;
using SpotiPie.Mappings;
using SpotiPie.Middleware;
using SpotiPie.Services;
using SpotiPie.Services.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(opts =>
{
    opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication().AddCookie("cookie");

builder.Services.AddTransient<IArtistService, ArtistService>();
builder.Services.AddTransient<ILyricsService, LyricsService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IAlbumService, AlbumService>();
builder.Services.AddTransient<IGenreService, GenreService>();
builder.Services.AddTransient<ITrackService, TrackService>();

builder.Services.AddScoped<GlobalExceptionHandling>();

builder.Services.AddDbContext<AppDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString(nameof(AppDbContext))));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandling>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.Use((HttpContext context, RequestDelegate next) =>
{
    return next(context);
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();