namespace App.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        public int CourseNumber { get; set; }
        public string CourseTitle { get; set; }
        public string CourseDesc { get; set; }
        public int CourseLength { get; set; }
        public string CourseLevel { get; set; }
        public bool Retired { get; set; }
    }
}