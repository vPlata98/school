using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace School.Models
{
    public partial class Person
    {
        public Person()
        {
            CourseInstructors = new HashSet<CourseInstructor>();
            StudentGrades = new HashSet<StudentGrade>();
        }

        public int PersonID { get; set; }
        public string LastName { get; set; }
        [Required()]
        public string FirstName { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? EnrollmentDate { get; set; }

        public virtual OfficeAssignment OfficeAssignment { get; set; }
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
    }
}
