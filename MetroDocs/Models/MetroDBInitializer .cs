using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MetroDocs.Models
{
    public class MetroDBInitializer :CreateDatabaseIfNotExists<MetroDBContext>
    {
        protected override void Seed(MetroDBContext context)
        {
           
           
        }
    }
}