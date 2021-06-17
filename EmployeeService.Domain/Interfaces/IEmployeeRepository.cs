using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Domain.Interfaces
{
    public interface IEmployeeRepository: IAsyncRepository<Employee>
    {        
        Task<IEnumerable<Employee>> GetEmployeeList();
        Task<string> GetEmployeeStatusById(long employeeId);
        Task<bool> GetHeadEmployee();
        Task<Employee> GetEmployeeById(long employeeId);
        Task<List<Employee>> SearchEmployee(Employee employee);
    }
}
