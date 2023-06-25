using System.ComponentModel.DataAnnotations;

namespace eTickets.Models.ViewModels
{
    public class CreateMovieVM 
    {
        [Display(Name ="Movie Name")]
        [Required(ErrorMessage ="Name is required !")]
        public string Name { get; set; }
        [Display(Name = "Movie Description !")]
        [Required(ErrorMessage = "Description is required !")]
        public string Description { get; set; }
        [Display(Name = "Movie Price")]
        [Required(ErrorMessage = "Price is required !")]
        public decimal Price { get; set; }
        [Display(Name = "Upload Image")]
        [Required(ErrorMessage = "Image is required !")]
        public string ImageURL { get; set; }
        [Display(Name = "Movie Start Date")]
        [Required(ErrorMessage = "Start Date is required !")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Movie End Date")]
        [Required(ErrorMessage = "End Date is required !")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Movie Category")]
        [Required(ErrorMessage = "Category  is required !")]
        public MovieCategory MovieCategory { get; set; }

        // navigation Properites 
        [Display(Name = "Select Cinema")]
        [Required(ErrorMessage = "Cinema is required ")]
        public int CinemaId { get; set; }
        [Display(Name = "Select Actor(s)")]
        [Required(ErrorMessage = "Name is required ")]
        public List<int> ActorIds { get; set; }
        [Display(Name = "Select Producer")]
        [Required(ErrorMessage = "Name is required ")]
        public int ProducerId { get; set; }
    }
}
