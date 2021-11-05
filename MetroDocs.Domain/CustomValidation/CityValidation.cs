using MetroDocs.Domain.MetroContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDocs.Domain.CustomValidation
{
    public class CityValidation: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string CityId = Convert.ToString(value);
            SqlParameter city = new SqlParameter("@CityId", CityId);
            using (MetroDBContext db = new MetroDBContext())
            {
                Int32? result = db.Database.SqlQuery<Int32>("Exec getCityListById @CityId", city).FirstOrDefault();
                if (Convert.ToInt32(result) > 0)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult
                   ("Invalid City.");
                }
            }
        }
    }
}
