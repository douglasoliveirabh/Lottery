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
            try
            {
                if (value == null) return new ValidationResult("Informe os números do seu bilhete.");

                var arrayValue = value.ToString().Split(",");
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
