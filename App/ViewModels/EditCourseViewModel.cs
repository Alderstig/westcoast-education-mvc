using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    public class EditCourseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Kursbeskrivning")]
        public string CourseDesc { get; set; }

        [Display(Name = "Kurslängd (H)")]
        public int CourseLength { get; set; }

        [Display(Name = "Pensionerad")]
        public bool Retired { get; set; }
    }
}