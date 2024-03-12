using Microsoft.EntityFrameworkCore;
using SpotiPie.Data;
using SpotiPie.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<ITextsService, TextService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString(nameof(AppDbContext))));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

