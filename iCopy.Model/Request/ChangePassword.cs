using System.ComponentModel.DataAnnotations;
using iCopy.Model.Attributes;

namespace iCopy.Model.Request
{
    public class ChangePassword
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ErrNoPassword")]
        [MaxLength(100, ErrorMessage = "ErrMaxLength")]
        [CurrentPassword(CurrentPasswordPropertyName = "id")]
        public string CurrentPassword { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "ErrNoPassword")]
        [MaxLength(100, ErrorMessage = "ErrMaxLength")]
        [MinLength(8, ErrorMessage = "ErrMinLenghtPassword")]
        [PasswordPolicy(ErrorMessage = "ErrPasswordPolicy")]
        public string NewPassword { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "ErrNoPassword")]
        [MaxLength(100, ErrorMessage = "ErrMaxLength")]
        [MinLength(8, ErrorMessage = "ErrMinLenghtPassword")]
        [PasswordPolicy(ErrorMessage = "ErrPasswordPolicy")]
        [Compare(nameof(NewPassword), ErrorMessage = "ErrNotSamePasswordConfirm")]
        public string ConfirmNewPassword { get; set; }
    }
}
