namespace iCopy.Model.Request
{
    public class CitySearch
    {
        public int? CountryID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int? PostalCode { get; set; }
        public bool? Active { get; set; }
    }
}
