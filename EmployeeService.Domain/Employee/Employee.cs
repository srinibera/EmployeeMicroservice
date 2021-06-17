using EmployeeService.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Domain
{
    public class Employee: BaseEntity
    {
        public long EmployeeId { get; set; }
        [Required]
        [StringLength(250)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [StringLength(250)]
        public string Email { get; set; }
        public long? ManagerID { get; set; }     
        public int DepartmentID { get; set; }
        public string Department { get; set; }
    }
}
