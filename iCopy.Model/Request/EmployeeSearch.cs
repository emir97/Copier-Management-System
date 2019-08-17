using System;
using System.Collections.Generic;
using System.Text;

namespace iCopy.Model.Request
{
    public class EmployeeSearch
    {
        public int? PersonId { get; set; }
        public int? CopierId { get; set; }
        public bool? Active { get; set; }
    }
}
