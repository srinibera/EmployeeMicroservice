using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.API.Features.Employee.Commands
{
    public class AddEmployeeCommand: IRequest<long>
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public long? ManagerID { get; set; }

        public string DepartmentID { get; set; }
    }
}
