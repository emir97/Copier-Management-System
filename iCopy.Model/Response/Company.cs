using System.ComponentModel.DataAnnotations.Schema;

namespace iCopy.Model.Response
{
    public class Company
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string ContactAgent { get; set; }
        public string Jib { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        [ForeignKey(nameof(City))]
        public int CityId { get; set; }
        public City City { get; set; }

        public string Email { get; set; }
    }
}
