using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using WebApplication1.Crypting;
using WebApplication1.Models;
using WebApplication1.Models.Interfaces;
using WebApplication1.Utilities;

namespace WebApplication1.Repositories
{
    public class DocumentRepository
    {
        public PersonalDocument Add(PersonalDocument entity)
        {
            string secretPhrase = GetSecretPhrase();
            var e = new MyXDocument(entity, secretPhrase);

            //write it to file
            //Utility.WriteEntityToXmlFile(entity);

            using (var db = new PersonalIdContext())
            {
                db.Documents.Add(e);
                db.SaveChanges();

                entity.Id = e.Id;
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
                    string secretPhrase = GetSecretPhrase();
                    i.XmlDocument = StringCipher.Decrypt(i.XmlDocument, secretPhrase);

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
                string secretPhrase = GetSecretPhrase();
                md.XmlDocument = StringCipher.Decrypt(md.XmlDocument, secretPhrase);
                PersonalDocument entity = Utility.ParseXmlToPersonalDocument(md.XmlDocument);
                entity.Id = md.Id;
                return entity;
            }
        }

        public PersonalDocument Update(PersonalDocument entity)
        {
            var xmlEntity = Utility.ConvertPersonalDocumentEntityToXml(entity);
            Utility.ValidateXmlEntity(xmlEntity);

            string secretPhrase = GetSecretPhrase();
            var e = new MyXDocument(entity, secretPhrase);

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
            string secretPhrase = GetSecretPhrase();
            var xEntity = new MyXDocument(entity, secretPhrase);

            using (var db = new PersonalIdContext())
            {
                var entry = db.Entry(xEntity);
                if (entry.State != EntityState.Deleted)
                {
                    entry.State = EntityState.Deleted;
                }
                else
                {
                    db.Set<MyXDocument>().Attach(xEntity);
                    db.Set<MyXDocument>().Remove(xEntity);
                }
                db.SaveChanges();
            }

        }

        private static string GetSecretPhrase()
        {
            return "pesho";
        }
    }
}