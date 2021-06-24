using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    public class EditParticipantViewmodel
    {
        public int Id { get; set; }
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }

        [Display(Name = "Efternamn")]
        public string LastName { get; set; }

        [Display(Name = "Emailadress")]
        public string Email { get; set; }

        [Display(Name = "Telefonnummer")]
        public string MobileNum { get; set; }

        [Display(Name = "Adress")]
        public string Adress { get; set; }
    }
}