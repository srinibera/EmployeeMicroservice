using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.API.Features.Employee.Commands
{
    public class DeleteEmployeeCommand: IRequest<long>
    {
        
        public long EmployeeId { get; set; }     
    }
}
