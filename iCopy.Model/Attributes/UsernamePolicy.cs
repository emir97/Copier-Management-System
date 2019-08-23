using System.ComponentModel.DataAnnotations;

namespace iCopy.Model.Attributes
{
    public class UsernamePolicy : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           
            return ValidationResult.Success;
        }
    }
}
