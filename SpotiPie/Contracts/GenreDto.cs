using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpotiPie.Entity;
using SpotiPie.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace SpotiPie.Contracts;

public record GenreDto
{
    [Range(0, 100, ErrorMessage ="{0} must be in between {1} and {2}")]
    public int ArtistId { get; set; }

    [Required(ErrorMessage = "{0} must not be null", AllowEmptyStrings = false)]
    public string? Country { get; init; }

    [DisplayName("Release Date")]
    [Required(ErrorMessage = "{0} cannot be null")]
    public DateTime Date { get; init; }

    [DisplayName("Type of Genres")]
    [EnumDataType(typeof(GenresEnum), ErrorMessage = "Invalid genre")]
    public GenresEnum GenreName { get; init; }

        

}
