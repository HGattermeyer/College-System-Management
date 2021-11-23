using System.Collections.Generic;

namespace College_System_Management.Models.ViewModels
{
    public class StudentFormViewModel
    {
        public Student Student { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
