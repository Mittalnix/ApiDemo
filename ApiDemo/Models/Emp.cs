﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ApiDemo.models
{
    public partial class Emp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Salary { get; set; }
        public int? Deptid { get; set; }
        public DateTime? Dob { get; set; }
        public string Email { get; set; }
    }
}
