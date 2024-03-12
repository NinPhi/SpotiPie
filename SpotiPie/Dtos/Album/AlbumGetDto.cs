using SpotiPie.Entities;

namespace SpotiPie.Dtos.Album
{
    public class AlbumGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ArtistId{ get; set; }
        public DateTime ReleaseYear { get; set; }
    }
}
