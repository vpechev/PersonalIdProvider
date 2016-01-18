using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Utilities;

namespace WebApplication1.App_Start
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<PersonalIdContext>
    {
        protected override void Seed(PersonalIdContext context)
        {
            var seedEntity = Utility.GetTestPersonalId(); 
            var repo = new DocumentRepository();
            repo.Add(seedEntity);
            context.SaveChanges();
        }
    }
}