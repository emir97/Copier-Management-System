using System;
using System.Collections.Generic;
using System.Text;

namespace iCopy.Model.Response
{
    public class Person
    {
        public string ID { get; set; }
        public bool Active { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Gender Gender { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }

    }
    public enum Gender
    {
        Male,
        Female
    }
}
