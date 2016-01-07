using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.Interfaces;

namespace WebApplication1.Models
{
    public class PersonEntity : Entity, IPersonEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsMale { get; set; }
        public string PersonalNumber { get; set; }
        public int Age { get; set; }
        DateTime BirthDate { get; set; }
        public int Height { get; set; }
        Address Adress {` get; set; }
    }
}