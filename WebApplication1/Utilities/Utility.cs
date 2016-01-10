using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using WebApplication1.Models;

namespace WebApplication1.Utilities
{
    public class Utility
    {
        public static PersonalDocument GetTestPersonalId()
        {
            var entity = new PersonalDocument()
            {
                Document = new DocumentEntity()
                {
                    DateOfDocumentExpiration = new DateTime(2020, 02, 21),
                    DateOfDocumentIssue = new DateTime(2016, 02, 21),
                    DocumentNumber = "89734593753"
                },
                Person = new PersonEntity()
                {
                    Age = 20,
                    BirthDate = new DateTime(1994, 02, 23),
                    FirstName = "ivan",
                    LastName = "ivanov",
                    IsMale = true,
                    PersonalNumber = "11231313131231",
                    Height = 213,
                    Address = new Address()
                    {
                        Country = "Bulgaria",
                        Town = "Lovech",
                        StreetName = "Street Bul",
                        StreetNumber = "21"
                    }
                }
            };
            return entity;
        }

        public static MyXDocument ConvertPersonalDocumentEntityToXml(PersonalDocument entity)
        {
            XDocument xmlDocumentEntity = new XDocument
                                          (
                                                new XElement("personalDocument",
                                                    new XElement("person",
                                                        new XElement("firstName", entity.Person.FirstName),
                                                        new XElement("lastName", entity.Person.LastName),
                                                        new XElement("isMale", entity.Person.IsMale),
                                                        new XElement("personalNumber", entity.Person.PersonalNumber),
                                                        new XElement("age", entity.Person.Age),
                                                        new XElement("birthDate", entity.Person.BirthDate),
                                                        new XElement("height", entity.Person.Height),
                                                        new XElement("address",
                                                               new XElement("country", entity.Person.Address.Country),
                                                               new XElement("town", entity.Person.Address.Town),
                                                               new XElement("streetName", entity.Person.Address.StreetName),
                                                               new XElement("streetNumber", entity.Person.Address.StreetNumber)
                                                                     )
                                                                ),
                                                    new XElement("document",
                                                        new XElement("documentNumber", entity.Document.DocumentNumber),
                                                        new XElement("dateOfIssue", entity.Document.DateOfDocumentIssue),
                                                        new XElement("dateOfExpiration", entity.Document.DateOfDocumentExpiration)
                                                                 )
                                                    )
                                            );

            return new MyXDocument() { XmlDocument = xmlDocumentEntity.ToString() };
        }

        public static PersonalDocument ParseXmlToPersonalDocument(String xmlString)
        {
            XDocument xmlEntity = XDocument.Parse(xmlString);

            var entity = new PersonalDocument()
            {
                Document = new DocumentEntity()
                {
                    DateOfDocumentExpiration = Convert.ToDateTime(xmlEntity.Root.Element("document").Element("dateOfExpiration").Value),
                    DateOfDocumentIssue = Convert.ToDateTime(xmlEntity.Root.Element("document").Element("dateOfIssue").Value),
                    DocumentNumber = xmlEntity.Root.Element("document").Element("documentNumber").Value.ToString()
                },
                Person = new PersonEntity()
                {
                    Age = Int32.Parse(xmlEntity.Root.Element("person").Element("age").Value),
                    BirthDate = Convert.ToDateTime(xmlEntity.Root.Element("person").Element("birthDate").Value),
                    FirstName = xmlEntity.Root.Element("person").Element("firstName").Value,
                    LastName = xmlEntity.Root.Element("person").Element("lastName").Value,
                    IsMale = Convert.ToBoolean(xmlEntity.Root.Element("person").Element("isMale").Value.ToString()),
                    PersonalNumber = xmlEntity.Root.Element("person").Element("personalNumber").Value,
                    Height = Int32.Parse(xmlEntity.Root.Element("person").Element("height").Value),
                    Address = new Address()
                    {
                        Country = xmlEntity.Root.Element("person").Element("address").Element("country").Value.ToString(),
                        Town = xmlEntity.Root.Element("person").Element("address").Element("town").Value.ToString(),
                        StreetName = xmlEntity.Root.Element("person").Element("address").Element("streetName").Value.ToString(),
                        StreetNumber = xmlEntity.Root.Element("person").Element("address").Element("streetNumber").Value.ToString(),
                    }
                }
            };

            return entity;
        }

        public static void WriteEntityToXmlFile(PersonalDocument entity, string fileName = "personalDocument")
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";

            using (XmlWriter writer = XmlWriter.Create("G:\\" + fileName + ".xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("personalDocument");

                writer.WriteStartElement("person");

                writer.WriteElementString("firstName", entity.Person.FirstName);
                writer.WriteElementString("lastName", entity.Person.LastName);
                writer.WriteElementString("isMale", entity.Person.IsMale.ToString());
                writer.WriteElementString("personalNumber", entity.Person.PersonalNumber.ToString());
                writer.WriteElementString("age", entity.Person.Age.ToString());
                writer.WriteElementString("birthDate", entity.Person.BirthDate.ToString());
                writer.WriteElementString("height", entity.Person.Height.ToString());

                writer.WriteStartElement("address");
                writer.WriteElementString("country", entity.Person.Address.Country);
                writer.WriteElementString("town", entity.Person.Address.Town);
                writer.WriteElementString("streetName", entity.Person.Address.StreetName);
                writer.WriteElementString("streetNumber", entity.Person.Address.StreetNumber.ToString());
                writer.WriteEndElement();

                writer.WriteEndElement();

                writer.WriteStartElement("document");
                writer.WriteElementString("documentNumber", entity.Document.DocumentNumber.ToString());
                writer.WriteElementString("dateOfIssue", entity.Document.DateOfDocumentIssue.ToString());
                writer.WriteElementString("dateOfExpiration", entity.Document.DateOfDocumentExpiration.ToString());
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        public static bool IsXmlDocValid(string filePath)
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", @"G:\Xml\personalDocument.xsd");

            Console.WriteLine("Attempting to validate");
            XDocument custOrdDoc = XDocument.Load(filePath);
            bool errors = false;
            custOrdDoc.Validate(schemas, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                errors = true;
            });
            return !errors;
        }


    }
}