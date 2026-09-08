using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class tblCourse
    {
        [Key] // <-- This tells EF that CourseId is the Primary Key
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public int DepartmentId { get; set; }
    }
}