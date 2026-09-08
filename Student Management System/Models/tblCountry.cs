using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class tblCountry
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}