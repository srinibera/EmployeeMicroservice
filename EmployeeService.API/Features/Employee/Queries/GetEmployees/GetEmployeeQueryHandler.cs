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
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, EmployeeDTO>
    {
        private readonly IEmployeeRepository  _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<EmployeeDTO> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employeeList = await _employeeRepository.GetEmployeeById(request.EmployeeId);            
            return _mapper.Map<EmployeeDTO>(employeeList);
        }
    }
}
