using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class tblCity
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
    }
}