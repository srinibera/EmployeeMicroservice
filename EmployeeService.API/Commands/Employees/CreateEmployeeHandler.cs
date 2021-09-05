using AutoMapper;
using EmployeeService.Domain.Common;
using EmployeeService.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.API.Features.Employee.Commands
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployee, long>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;        
        private readonly ILogger<CreateEmployeeHandler> _logger;
        private readonly IEmailService _emailService;

        public CreateEmployeeHandler(IEmployeeRepository employeeRepository, IEmailService emailService, IMapper mapper, ILogger<CreateEmployeeHandler> logger)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
            _emailService = emailService;
        }

        public async Task<long> Handle(CreateEmployee request, CancellationToken cancellationToken)
        {            
            var employeeEntity = _mapper.Map<Domain.Employee>(request);
            if(employeeEntity.ManagerID == null)
            {

            }
            var newEmp = await _employeeRepository.AddAsync(employeeEntity);

            _logger.LogInformation($"New Employee {newEmp.EmployeeId} is created successfully.");

            await _emailService.SendEmail(new Email() { Body = $"New Employee was created.", Subject = "New Employee Added" });

            return newEmp.EmployeeId;
        }

    }
}
