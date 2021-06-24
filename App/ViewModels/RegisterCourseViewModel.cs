using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    public class RegisterCourseViewModel
    {
        [Display(Name = "Kursnummer")]
        [Required(ErrorMessage = "Kursnummer måste anges!")]
        public int CourseNumber { get; set; }

        [Display(Name = "Kurstitel")]
        [Required(ErrorMessage = "Kurstitel måste anges!")]
        public string CourseTitle { get; set; }

        [Display(Name = "Kursbeskrivning")]
        public string CourseDesc { get; set; }

        [Display(Name = "Kurslängd (H)")]
        [Required(ErrorMessage = "Registeringsnummer måste anges!")]
        public int CourseLength { get; set; }

        [Display(Name = "Kursnivå")]
        [Required(ErrorMessage = "Registeringsnummer måste anges!")]
        public string CourseLevel { get; set; }

        [Display(Name = "Pensionerad")]
        public bool Retired { get; set; }
    }
}