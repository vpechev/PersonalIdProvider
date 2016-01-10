using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DocumentEntity
    {
        public string DocumentNumber { get; set; }
        public DateTime DateOfDocumentIssue { get; set; }
        public DateTime DateOfDocumentExpiration { get; set; }
    }
}