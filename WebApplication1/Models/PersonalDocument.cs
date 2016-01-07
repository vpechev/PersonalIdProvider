using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Interfaces
{
    public class PersonalDocument
    {
        public PersonEntity Person { get; set; }
        public DocumentEntity Document { get; set; }
        DateTime DateOfDocumentIssue { get; set; }
        DateTime DateOfDocumentExpiration { get; set; }
    }
}
