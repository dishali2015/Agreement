using MetroDocs.Domain.MetroContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDocs.Domain.CustomValidation
{
    public class MobileDuplicate : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string MobileNo = Convert.ToString(value);

            return ValidationResult.Success;
        }
    }
}
