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
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, long>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;        
        private readonly ILogger<AddEmployeeCommandHandler> _logger;
        private readonly IEmailService _emailService;

        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IEmailService emailService, IMapper mapper, ILogger<AddEmployeeCommandHandler> logger)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
            _emailService = emailService;
        }

        public async Task<long> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeEntity = _mapper.Map<Domain.Employee>(request);
            await _employeeRepository.UpdateAsync(employeeEntity);

            _logger.LogInformation($"Update Employee {employeeEntity.EmployeeId} is successfull.");

            await _emailService.SendEmail(new Email() { Body = $"Updated employee info", Subject = "Update Employee" });
            return employeeEntity.EmployeeId;
        } 

    }
}
