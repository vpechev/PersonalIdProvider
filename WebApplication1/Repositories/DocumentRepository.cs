using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using WebApplication1.Models;
using WebApplication1.Models.Interfaces;
using WebApplication1.Utilities;

namespace WebApplication1.Repositories
{
    public class DocumentRepository
    {
        public PersonalDocument Add(PersonalDocument entity)
        {
            MyXDocument xmlEntity = Utility.ConvertPersonalDocumentEntityToXml(entity);

            using (var db = new PersonalIdContext())
            {
                db.Documents.Add(xmlEntity);
                db.SaveChanges();

                entity.Id = xmlEntity.Id;
                return entity;
            } 
        }

        public IEnumerable<PersonalDocument> GetAll()
        {
            IList<PersonalDocument> results = new List<PersonalDocument>();
            using (var db = new PersonalIdContext())
            {
                IList<MyXDocument> mds = db.Documents.ToList();
                foreach (var i in mds)
                {
                    PersonalDocument entity = Utility.ParseXmlToPersonalDocument(i.XmlDocument);
                    entity.Id = i.Id;
                    results.Add(entity);
                }
                return results;
            } 
        }

        public PersonalDocument GetById(int id)
        {
            using (var db = new PersonalIdContext())
            {
                MyXDocument md = db.Documents.Find(id);
                PersonalDocument entity = Utility.ParseXmlToPersonalDocument(md.XmlDocument);
                entity.Id = md.Id;
                return entity;
            } 
        }

        public PersonalDocument Update(PersonalDocument entity)
        {
            var e = new MyXDocument()
            {
                Id = entity.Id,
                XmlDocument = Utility.ConvertPersonalDocumentEntityToXml(entity).ToString()
            };

            using (var db = new PersonalIdContext())
            {
                var dbEntity = db.Documents.Single(a => a.Id == entity.Id);
                dbEntity = e;
                db.SaveChanges();
                
                return entity;
            } 
        }

        public void Delete(int id)
        {
            var entity = this.GetById(id);
            if (entity != null)
            {
                this.Delete(entity);
            } 
        }

        public void Delete(PersonalDocument entity)
        {
            MyXDocument xEntity = new MyXDocument()
            {
                Id = entity.Id,
                XmlDocument = Utility.ConvertPersonalDocumentEntityToXml(entity).ToString()
            };

            using (var db = new PersonalIdContext())
            {
                var entry = db.Documents.Remove(xEntity);
            }

        }
    }
}