namespace SpotiPie.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseYear { get; set; }
        public int ArtistId { get; set; }
    }
}
