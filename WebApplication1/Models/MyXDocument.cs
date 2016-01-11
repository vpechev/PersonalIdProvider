using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using WebApplication1.Crypting;
using WebApplication1.Utilities;

namespace WebApplication1.Models
{
    public class MyXDocument
    {
        public int Id { get; set; }
        public string XmlDocument { get; set; }

        public MyXDocument() { }

        public MyXDocument(PersonalDocument entity, string encryptingPhrase)
        {
            XDocument xmlEntity = Utility.ConvertPersonalDocumentEntityToXml(entity);
            
            if (!Utility.IsXmlDocValid(xmlEntity))
                throw new ArgumentException();

            this.Id = entity.Id;
            this.XmlDocument = StringCipher.Encrypt(xmlEntity.ToString(), encryptingPhrase);
        }
    }
}