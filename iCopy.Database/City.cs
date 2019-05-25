using System.ComponentModel.DataAnnotations.Schema;

namespace iCopy.Database
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public string ShortName { get; set; }

        [ForeignKey(nameof(Country))]
        public int CityID { get; set; }
        public Country Country { get; set; }
    }
}
