using System;
using System.Collections.Generic;
using System.Text;

namespace AdminEmployees.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public Area Area { get; set; }
        public SubArea  SubArea { get; set; }

    }
}
