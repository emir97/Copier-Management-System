namespace iCopy.Model.Request
{
    public class CompanySearch
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactAgent { get; set; }
        public int CountryID { get; set; }
        public int CityID { get; set; }
        public bool? Active { get; set; }
    }
}
