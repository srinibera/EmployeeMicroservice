using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.API.Features.Employee.Commands
{
    public class DeleteEmployee: IRequest<long>
    {
        
        public long EmployeeId { get; set; }     
    }
}
