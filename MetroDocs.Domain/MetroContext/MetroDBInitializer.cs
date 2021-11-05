using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDocs.Domain.MetroContext
{
    public class MetroDBInitializer : CreateDatabaseIfNotExists<MetroDBContext>
    {
        protected override void Seed(MetroDBContext context)
        {


        }
    }
}
