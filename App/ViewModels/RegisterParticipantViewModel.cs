using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    public class RegisterParticipantViewModel
    {
        [Display(Name = "Förnamn")]
        [Required(ErrorMessage = "Förnamn måste anges!")]
        public string FirstName { get; set; }

        [Display(Name = "Efternamn")]
        [Required(ErrorMessage = "Efternamn måste anges!")]
        public string LastName { get; set; }

        [Display(Name = "Emailadress")]
        [Required(ErrorMessage = "Emailadress måste anges!")]
        public string Email { get; set; }

        [Display(Name = "Telefonnummer")]
        [Required(ErrorMessage = "Telefonnummer måste anges!")]
        public string MobileNum { get; set; }

        [Display(Name = "Adress")]
        [Required(ErrorMessage = "Adress måste anges!")]
        public string Adress { get; set; }
    }
}