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
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{FirstName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{FirstName} must not exceed 250 characters.");
            
            RuleFor(p => p.LastName)
               .NotEmpty().WithMessage("{LastName} is required.")
               .NotNull()
               .MaximumLength(250).WithMessage("{LastName} must not exceed 250 characters.");

            RuleFor(p => p.DepartmentId)
               .NotEmpty().WithMessage("{DepartmentId} is required.")
               .NotNull();              

            RuleFor(p => p.Email)
               .NotEmpty().WithMessage("{Email} is required.");          
        }
    }
}
