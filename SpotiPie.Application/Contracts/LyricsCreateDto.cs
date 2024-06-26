﻿using System.ComponentModel.DataAnnotations;

namespace SpotiPie.Application.Contracts;

public record LyricsCreateDto
{
    [Required]
    public int TrackId { get; init; }

    [Required(AllowEmptyStrings = false)]
    [StringLength(4000)]
    public string? Text { get; init; }

    [StringLength(4000)]
    public string? Translation { get; init; }
}
