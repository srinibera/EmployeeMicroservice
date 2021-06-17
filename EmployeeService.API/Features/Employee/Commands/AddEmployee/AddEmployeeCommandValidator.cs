using AutoMapper;
using EmployeeService.Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeService.API.Features.Employee.Commands
{
    public class AddEmployeeCommandValidator : AbstractValidator<AddEmployeeCommand>
    {
        IEmployeeRepository _employeeRepository;
        public AddEmployeeCommandValidator(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{FirstName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{FirstName} must not exceed 250 characters.");

            RuleFor(p => p.LastName)
               .NotEmpty().WithMessage("{LastName} is required.")
               .NotNull()
               .MaximumLength(250).WithMessage("{LastName} must not exceed 250 characters.");

            RuleFor(p => p.DepartmentID)
               .NotEmpty().WithMessage("{DepartmentID} is required.")
               .NotNull();

            if (CheckHeadEmployee())
            {
                RuleFor(p => p.ManagerID)
                    .NotEmpty().WithMessage("{ManagerID} is required.")
                    .NotNull();
            }
            else
            {
                RuleFor(p => p.ManagerID);                                 
            }
           
            RuleFor(p => p.Email)
               .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
               .NotEmpty().WithMessage("{Email} is required.");
        }

        private bool CheckHeadEmployee()
        {
            return _employeeRepository.GetHeadEmployee().GetAwaiter().GetResult();           
        } 
    }
}
