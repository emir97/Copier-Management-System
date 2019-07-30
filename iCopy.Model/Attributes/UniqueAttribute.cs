using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using iCopy.Database.Context;
using Microsoft.Extensions.Localization;

namespace iCopy.Model.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.Field, AllowMultiple = false)]
    public class UniqueAttribute : ValidationAttribute
    {
        public string Type { get; set; }

        public UniqueAttribute() : base((Func<string>) (() => "ErrNoName"))
        {
            
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            AuthContext context = validationContext.GetService<AuthContext>();
            IStringLocalizerFactory factory = validationContext.GetService<IStringLocalizerFactory>();
            IStringLocalizer localizer = factory.Create("ValidationErrors", "iCopy.Web");
            if (Type == null) throw new ArgumentNullException("Type in unique attribute is null");
            if (value != null)
            {
                if (Type == Username && context.Users.Any(x => x.UserName == value.ToString()))
                    return new ValidationResult(ErrorMessageString);
                if (Type == PhoneNumber && context.Users.Any(x => x.PhoneNumber == value.ToString()))
                    return new ValidationResult(ErrorMessageString);
                if (Type == Email && context.Users.Any(x => x.Email == value.ToString()))
                    return new ValidationResult(ErrorMessageString);
            }
            return null;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format((IFormatProvider)CultureInfo.CurrentCulture, this.ErrorMessageString, (object)name);
        }

        public const string Username = "USERNAME";
        public const string PhoneNumber = "PHONENUMBER";
        public const string Email = "EMAIL";
    }
}