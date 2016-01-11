using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models.Interfaces;

namespace WebApplication1.Models
{
    public class PersonEntity : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsMale { get; set; }
        public string PersonalNumber { get; set; }
        public int Age { get; set; }

        [DisplayName("Joining date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public int Height { get; set; }
        public Address Address { get; set; }
    }
}