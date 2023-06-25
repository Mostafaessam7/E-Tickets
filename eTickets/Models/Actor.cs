namespace eTickets.Models
{
    public class Actor : BaseModel
    {
        public Actor()
        {
        }
        //navigation properties
        public List<Actor_Movie> Movies { get; set; }

    }
}
