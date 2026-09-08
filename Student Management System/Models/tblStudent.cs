using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class tblStudent
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
    }
}