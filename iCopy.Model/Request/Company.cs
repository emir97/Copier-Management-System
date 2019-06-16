using Microsoft.AspNetCore.Http;

namespace iCopy.Model.Request
{
    public class Company
    {
        public string Name { get; set; }
        public string ContactAgent { get; set; }
        public string Jib { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public IFormFile File { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}
