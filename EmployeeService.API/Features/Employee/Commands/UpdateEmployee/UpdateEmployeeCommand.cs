using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.API.Features.Employee.Commands
{
    public class UpdateEmployeeCommand: IRequest<long>
    {
        public long EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string DepartmentId { get; set; }
    }
}
