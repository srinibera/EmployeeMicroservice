using AutoMapper;
using EmployeeService.API.DTO;
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
    public class GetEmployeesFilterQueryHandler : IRequestHandler<GetEmployeesFilterQuery, List<EmployeeDTO>>
    {
        private readonly IEmployeeRepository  _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeesFilterQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDTO>> Handle(GetEmployeesFilterQuery request, CancellationToken cancellationToken)
        {
            var emp= _mapper.Map<Domain.Employee>(request.Employee);
            var employeeList = await _employeeRepository.SearchEmployee(emp);         
            return _mapper.Map<List<EmployeeDTO>>(employeeList);
        }
    }
}
