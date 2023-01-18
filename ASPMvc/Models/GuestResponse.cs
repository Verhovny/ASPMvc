using System.ComponentModel.DataAnnotations;
namespace ASPMvc.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage="Please, enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, enter your email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, enter your phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please, enter your attend")]
        public bool? WillAttendant { get; set; }
    }
}