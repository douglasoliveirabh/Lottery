using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.UI.Annotations
{
    public class NumerosValidos : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;
            var arrayValue = value.ToString().Split(",");
            try
            {
                var intArrayValue = arrayValue.Select(x => int.Parse(x)).ToArray();
                return ValidationResult.Success;
            }
            catch (Exception)
            {
                return new ValidationResult("Números Inválidos.");                
            }
        }


    }
}
