using iCopy.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace iCopy.Model.Request
{
    public class EmployeeSearch
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? CopierId { get; set; }
        public int? CompanyId { get; set; }
        public int? CityId { get; set; }
        public int? CountryId { get; set; }
        public Gender? Gender { get; set; }
        public bool? Active { get; set; }
    }
}
