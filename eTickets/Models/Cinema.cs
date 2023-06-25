using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema:IEntityBase
    {
        public int id { get; set; }
        [Display(Name ="Cinema Name")]
        public string Name { get; set; }
        [Display(Name ="Description")]
        public string Description { get; set; }
        [Display(Name ="Cinema Logo")]
        public string Logo { get; set; }

        // navigation Properties 
        public List<Movie> Movies { get; set; }
    }
}
