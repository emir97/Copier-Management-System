using System.ComponentModel.DataAnnotations;

namespace User.Model
{
    public class LoginResult
    {
        [Required(ErrorMessage = "ErrNoUsername")]
        [MaxLength(100, ErrorMessage =  "ErrMaxLengthUsername")]
        [DataType(DataType.Text, ErrorMessage = "ErrDataTypeUsername")]
        public string Username { get; set; }
        [Required(ErrorMessage = "ErrNoPassword")]
        [MaxLength(100, ErrorMessage = "ErrMaxLengthPassword")]
        [DataType(DataType.Password, ErrorMessage = "ErrDataTypePassword")]
        public string Password { get; set; }
    }
}
