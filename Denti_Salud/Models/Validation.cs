using System.ComponentModel.DataAnnotations;

namespace Denti_Salud.Models
{
    public class SexoValidacion : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((value.ToString().ToUpper() == "M") || (value.ToString().ToUpper() == "F"))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage);
            
        }
    }
    public class TipoIdentificacionValidacion : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((value.ToString().ToUpper() == "CC") || (value.ToString().ToUpper() == "TI") || (value.ToString().ToUpper() == "RC"))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage);
            
        }
    }
    public class RolValidacion : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
        if ((value.ToString().ToUpper() == "PCN") || (value.ToString().ToUpper() == "ODN") || (value.ToString().ToUpper() == "RCP") || (value.ToString().ToUpper() == "ADM"))
        {
            return ValidationResult.Success;
        }
        return new ValidationResult(ErrorMessage);

        }
    }
    public class MotivoValidacion : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((value.ToString().ToUpper() == "PrimeraVez") || (value.ToString().ToUpper() == "TR") || (value.ToString().ToUpper() == "UR") || (value.ToString().ToUpper() == "PyP"))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage);

        }
    }
}
