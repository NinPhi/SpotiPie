namespace SpotiPie.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string Pseudonym { get; set; }
        public int? Followers { get; set; }
        public int? MonthlyListeners { get; set; }
    }
}