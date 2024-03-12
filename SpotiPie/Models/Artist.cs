using System.ComponentModel.DataAnnotations;

namespace SpotiPie.Models
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }
        public string Pseudonym { get; set; }
        public int? Followers { get; set; }
        public List<string>? Albums { get; set; }
        public List<string>? TopListened { get; set; }
        public int? MonthlyListeners { get; set; }
    }
    
}
