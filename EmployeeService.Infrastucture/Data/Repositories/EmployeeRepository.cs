using EmployeeService.Domain;
using EmployeeService.Domain.Interfaces;
using EmployeeService.Infrastructure.Data.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Infrastructure.Data.Repositories
{
    public class EmployeeRepository: RepositoryBase<Employee>, IEmployeeRepository
    {    
        public EmployeeRepository(EmployeeDBContext dbContext) : base(dbContext)
        {
             
        }

        public async Task<string> GetEmployeeStatusById(long employeeId)
        {
            var employee = await GetByIdAsync(employeeId);
            if (employee !=null && employee.ManagerID ==null){
                return "Head";
            }

            IReadOnlyList<Employee> employeeList = await GetAsync(e=>e.ManagerID==employee.EmployeeId);
            if (employeeList != null && employeeList.Count>0)
            {
                return "Manager";
            }
            return "Associate";
        }

        public async Task<Employee> GetEmployeeById(long employeeId)
        {
            var employee = await GetByIdAsync(employeeId);
            return employee;
        }

        public Task<IEnumerable<Employee>> GetEmployeeList()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Employee>> SearchEmployee(Employee employee)
        {
            if(employee.EmployeeId > 0)
            {
                var filteredEmployee= await GetEmployeeById(employee.EmployeeId);
                return new List<Employee>() { filteredEmployee };
            }
            else if (employee.EmployeeId > 0 && employee.DepartmentID>0 && !string.IsNullOrEmpty(employee.FirstName) && !string.IsNullOrEmpty(employee.FirstName))
            {
                var empList =await DBContext.Set<Employee>()
                    .Where(e => e.EmployeeId == employee.EmployeeId)
                    .Where(e=>e.DepartmentID == employee.DepartmentID )
                    .Where(e=>e.FirstName == employee.FirstName )
                    .Where(e=>e.LastName== employee.LastName).ToListAsync();
                return empList.OrderBy(e => e.FirstName).ToList();
            }
            else
            {                
                var empList = await DBContext.Set<Employee>()
                    .Where(e => e.DepartmentID == employee.DepartmentID).ToListAsync();                                        

                return empList.OrderBy(e => e.FirstName).ToList();
            }
            
        }

        public async Task<bool> GetHeadEmployee()
        {
            IReadOnlyList<Employee> headEmployee = await GetAsync(e => e.ManagerID == null);
            return headEmployee.Count > 0 ? true : false;
            
        }
    }
}
