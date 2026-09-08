using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class tblDepartment
    {
        [Key] // <-- This is what Entity Framework was looking for!
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }
    }
}