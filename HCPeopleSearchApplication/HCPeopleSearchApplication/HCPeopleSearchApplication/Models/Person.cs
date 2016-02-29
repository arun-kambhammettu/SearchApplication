using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace HCPeopleSearchApplication.Models
{
    public class Person
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public string Interests { get; set; }

        public byte[] image { get; set; }
        public string FileName { get; set; }
      
        public string ContentType { get; set; }

       
    }
}