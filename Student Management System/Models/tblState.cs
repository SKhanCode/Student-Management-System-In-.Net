using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class tblState
    {
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
    }
}