using EmployeeService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Features.Employee.Queries
{
    public class GetEmployeeQuery : IRequest<EmployeeDTO>
    {
        public long EmployeeId { get; set; }

        public GetEmployeeQuery(long employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
