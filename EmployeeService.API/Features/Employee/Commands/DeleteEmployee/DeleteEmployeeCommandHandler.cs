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
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, long>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;        
        private readonly ILogger<AddEmployeeCommandHandler> _logger;
        private readonly IEmailService _emailService;

        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository, IEmailService emailService, IMapper mapper, ILogger<AddEmployeeCommandHandler> logger)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
            _emailService = emailService;
        }

        public async Task<long> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeEntity = _mapper.Map<Domain.Employee>(request);
            await _employeeRepository.DeleteAsync(employeeEntity);

            _logger.LogInformation($"Deleting Employee {employeeEntity.EmployeeId} is successfull.");

            await _emailService.SendEmail(new Email() { Body = $"Deleted employee {employeeEntity.EmployeeId}", Subject = "Deleted employee" });
            
            return employeeEntity.EmployeeId;
        }

    }
}
