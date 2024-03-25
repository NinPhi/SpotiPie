using System.ComponentModel.DataAnnotations;

namespace SpotiPie.Entities;

public class TrackData
{
    [Key]
    public required int TrackId { get; set; }

    [StringLength(200)]
    public required string FileName { get; set; }

    [StringLength(100)]
    public required string MediaType { get; set; }

    public required byte[] Data { get; set; }

    public Track? Track { get; set; }
}
