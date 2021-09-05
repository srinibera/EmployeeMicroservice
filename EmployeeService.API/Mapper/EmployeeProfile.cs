using AutoMapper;
using EmployeeService.API.DTO;
using EmployeeService.API.Features.Employee.Commands;
using EmployeeService.Domain;
using EmployeeService.Features.Employee.Queries;

namespace EmployeeService.API.Mapper
{
    public class EmployeeProfile : Profile
	{
		public EmployeeProfile()
		{
			CreateMap<Employee, EmployeeDTO>().ReverseMap();
			CreateMap<CreateEmployee, Employee>().ReverseMap();
			CreateMap<DeleteEmployee, Employee>().ReverseMap();
			CreateMap<UpdateEmployee, Employee>().ReverseMap();
		}
	}
}
