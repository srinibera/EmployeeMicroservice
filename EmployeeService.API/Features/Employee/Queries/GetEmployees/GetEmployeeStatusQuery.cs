using EmployeeService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Features.Employee.Queries
{
    public class GetEmployeeStatusQuery : IRequest<string>
    {
        public long EmployeeId { get; set; }

        public GetEmployeeStatusQuery(long employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
