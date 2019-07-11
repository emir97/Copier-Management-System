using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using iCopy.Database.Context;

namespace iCopy.Model.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.Field, AllowMultiple = false)]
    public class UniqueAttribute : ValidationAttribute
    {
        public string Type { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            AuthContext context = validationContext.GetService<AuthContext>();
            if (Type == null) throw new ArgumentNullException("Type in unique attribute is null");
            if (Type == Username && context.Users.Any(x => x.UserName == value.ToString()))
                return new ValidationResult(ErrorMessage);
            if (Type == PhoneNumber && context.Users.Any(x => x.PhoneNumber == value.ToString()))
                return new ValidationResult(ErrorMessage);
            if (Type == Email && context.Users.Any(x => x.Email == value.ToString()))
                return new ValidationResult(ErrorMessage);
            return null;
        }

        public const string Username = "USERNAME";
        public const string PhoneNumber = "PHONENUMBER";
        public const string Email = "EMAIL";
    }
}