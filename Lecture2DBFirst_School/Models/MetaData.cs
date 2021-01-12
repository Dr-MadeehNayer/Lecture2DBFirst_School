using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lecture2DBFirst_School.Models
{
    public class StudentMetaData
    {
        [StringLength(50)]
        [Required(ErrorMessage ="Student must have a first name!")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Student must have a last name!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Enrollment Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        public Nullable<System.DateTime> EnrollmentDate { get; set; }
    }

    public class CourseMetaData
    {
        [StringLength(50)]
        [Required(ErrorMessage = "Course must have a title!")]
        public string Title { get; set; }

        [Range(2,6)]
        public Nullable<int> Credits { get; set; }

        [Display(Name = "Course Description")]
        public string CourseDescription { get; set; }
    }

    public class EnrollmentMetaData
    {
        [Required(ErrorMessage ="Fill in the grade!")]
        [Range(0,100)]
        public Nullable<decimal> Grade { get; set; }
    }
}