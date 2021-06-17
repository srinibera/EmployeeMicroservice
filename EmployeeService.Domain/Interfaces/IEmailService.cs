using EmployeeService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Domain.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
