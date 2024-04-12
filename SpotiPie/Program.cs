using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using SpotiPie.Middleware;
using SpotiPie.Services;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(opts =>
{
    opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

var securityKey = Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecurityKey"]!);

// Настройка JWT аутентификации
builder.Services.AddAuthentication(opts =>
{
    opts.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
{
    opts.MapInboundClaims = false;
    opts.SaveToken = false;
    opts.TokenValidationParameters = new()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(securityKey),
        ValidateAudience = false,
        ValidateIssuer = false,
        RequireExpirationTime = true,
    };
});

// Настройка дефолтной авторизации
builder.Services
    .AddAuthorizationBuilder()
    .SetFallbackPolicy(new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build());

builder.Services.AddSingleton<IPasswordManager, PasswordManager>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<IArtistService, ArtistService>();
builder.Services.AddTransient<ILyricsService, LyricsService>();
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