﻿using iCopy.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace iCopy.Model.Request
{
    public class PrintRequestSearch
    {
        public int? CopierId { get; set; }
        public int? ClientId { get; set; }
        public Status Status{ get; set; }
    }
}
