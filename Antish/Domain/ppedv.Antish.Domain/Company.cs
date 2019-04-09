using System;
using System.Collections.Generic;

namespace ppedv.Antish.Domain
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public virtual HashSet<Department> Departments { get; set; } = new HashSet<Department>();
        public DateTime FoundingYear { get; set; }
        public decimal AnnualIncome { get; set; }
    }

}
