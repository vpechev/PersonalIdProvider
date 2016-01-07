using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.Interfaces;

namespace WebApplication1.Models
{
    public class Entity : IEntity
    {
        public string Id { get; set; }
    }
}