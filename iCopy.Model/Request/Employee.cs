using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iCopy.Model.Request
{
    public class Employee
    {
        [Required(ErrorMessage = "ErrNoPerson")]
        public int? PersonId { get; set; }
        [Required(ErrorMessage = "ErrNoCopier")]
        public int? CopierId { get; set; }
        [Required(ErrorMessage = "ErrNoPassword")]
        public int Password { get; set; }
        public bool Active { get; set; }
        public Model.Request.ApplicationUserInsert User { get; set; }
        public Model.Request.ProfilePhoto ProfilePhoto { get; set; }
    }
}
