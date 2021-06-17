using EmployeeService.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Features.Employee.Queries
{
    public class EmployeeDTO
    {
        public long EmployeeId { get; set; }
       
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int DepartmentID { get; set; }
        
        public string Email { get; set; }
        public long? ManagerID { get; set; }
        
    }
}
