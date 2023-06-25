namespace eTickets.Models
{
    public class Movie:IEntityBase
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string  Description { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }

        // navigation Properites 
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        public List<Actor_Movie> Actors { get; set; }
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
    }
}
