using eTickets.Models;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class BaseModel :IEntityBase
    {
        public int id { get; set; }
        [Display(Name ="Profile Picture")]
        [Required(ErrorMessage ="profile picture is requierd !")]
        public string ProfilePictureURL { get; set; }

        [Display(Name ="Full Name")]

        [Required(ErrorMessage ="Full name is required !")]

        [StringLength(50,MinimumLength =3, ErrorMessage ="full name must be between 3 and 50 chars ")]
        public string FullName { get; set; }
        [Display(Name ="Biography")]
        [Required(ErrorMessage ="Biography is required !")]
        public string Bio { get; set; }
    }
}
