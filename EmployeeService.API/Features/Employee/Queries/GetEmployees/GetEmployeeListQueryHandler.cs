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
    public class GetEmployeeListQueryHandler : IRequestHandler<GetEmployeeListQuery,List<EmployeeDTO>>
    {
        private readonly IEmployeeRepository  _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeListQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDTO>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var employeeList = await _employeeRepository.GetAllAsync();            
            return _mapper.Map<List<EmployeeDTO>>(employeeList);
        }
    }
}
