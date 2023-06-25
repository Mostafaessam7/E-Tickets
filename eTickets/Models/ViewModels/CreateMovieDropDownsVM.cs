namespace eTickets.Models.ViewModels
{
    public class CreateMovieDropDownsVM
    {
        public CreateMovieDropDownsVM()
        {
        }

        public CreateMovieDropDownsVM(List<Producer> producers, List<Actor> actors, List<Cinema> cinemas)
        {
            Producers = producers;
            Actors = actors;
            Cinemas = cinemas;
        }

        public List<Producer> Producers { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Cinema> Cinemas { get; set; }


    }
}
