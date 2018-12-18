using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Storage.Database.Models
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee
    {
        [Key]
        public Guid EmployeeGuid { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Employee()
        {
            EmployeeGuid = Guid.NewGuid();
        }
    }
}
