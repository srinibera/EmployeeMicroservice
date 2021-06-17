using EmployeeService.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Domain
{
    public class Department: BaseEntity
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        [StringLength(250)]
        public string DepartmentName { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
