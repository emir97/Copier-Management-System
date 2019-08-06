using System.ComponentModel.DataAnnotations;
using iCopy.Database.Context;
using Microsoft.Extensions.DependencyInjection;

namespace iCopy.Model.Attributes
{
    public class CurrentPassword : ValidationAttribute
    {
        public string CurrentPasswordPropertyName { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DBContext context = validationContext.GetService<DBContext>();
            
            return ValidationResult.Success;;
        }
    }
}
