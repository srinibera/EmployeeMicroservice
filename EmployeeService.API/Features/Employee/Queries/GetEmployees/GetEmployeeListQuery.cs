using EmployeeService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Features.Employee.Queries
{
    public class GetEmployeeListQuery : IRequest<List<EmployeeDTO>>
    {
      

        public GetEmployeeListQuery()
        {
             
        }
    }
}
