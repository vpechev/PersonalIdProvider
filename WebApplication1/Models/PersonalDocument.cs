using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.Interfaces;

namespace WebApplication1.Models
{
    public class PersonalDocument : Entity
    {
        public PersonEntity Person { get; set; }
        public DocumentEntity Document { get; set; }
        
    }
}
