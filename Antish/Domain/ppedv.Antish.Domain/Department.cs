using System.Collections.Generic;

namespace ppedv.Antish.Domain
{
    public class Department : Entity
    {
        public string Name { get; set; }
        public virtual Person HeadOfDepartment { get; set; }
        public virtual HashSet<Person> Members { get; set; } = new HashSet<Person>();
    }

}
