using EmployeeService.API.DTO;
using EmployeeService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Features.Employee.Queries
{
    public class GetEmployeesFilterQuery : IRequest<List<EmployeeDTO>>
    {
        public EmployeeDTO Employee { get; set; }

        public GetEmployeesFilterQuery(EmployeeDTO employee)
        {
            Employee = employee;
        }
    }
}
