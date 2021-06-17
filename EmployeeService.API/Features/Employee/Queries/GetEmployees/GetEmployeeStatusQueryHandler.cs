using AutoMapper;
using EmployeeService.Domain;
using EmployeeService.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.Features.Employee.Queries
{
    public class GetEmployeeStatusQueryHandler : IRequestHandler<GetEmployeeStatusQuery, string>
    {
        private readonly IEmployeeRepository  _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeStatusQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(GetEmployeeStatusQuery request, CancellationToken cancellationToken)
        {
            var estatus = await _employeeRepository.GetEmployeeStatusById(request.EmployeeId);
            return estatus;
        }
    }
}
