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
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployee, long>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;        
        private readonly ILogger<DeleteEmployeeHandler> _logger;
        private readonly IEmailService _emailService;

        public DeleteEmployeeHandler(IEmployeeRepository employeeRepository, IEmailService emailService, IMapper mapper, ILogger<DeleteEmployeeHandler> logger)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
            _emailService = emailService;
        }

        public async Task<long> Handle(DeleteEmployee request, CancellationToken cancellationToken)
        {
            var employeeEntity = _mapper.Map<Domain.Employee>(request);
            await _employeeRepository.DeleteAsync(employeeEntity);

            _logger.LogInformation($"Deleting Employee {employeeEntity.EmployeeId} is successfull.");

            await _emailService.SendEmail(new Email() { Body = $"Deleted employee {employeeEntity.EmployeeId}", Subject = "Deleted employee" });
            
            return employeeEntity.EmployeeId;
        }

    }
}
