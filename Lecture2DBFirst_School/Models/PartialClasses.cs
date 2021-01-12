using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Lecture2DBFirst_School.Models;

namespace Lecture2DBFirst_School.Models
{
    [MetadataType(typeof(StudentMetaData))]
    public partial class Student
    {

    }

    [MetadataType(typeof(CourseMetaData))]
    public partial class Course
    {

    }

    [MetadataType(typeof(EnrollmentMetaData))]
    public partial class Enrollment
    {

    }
}