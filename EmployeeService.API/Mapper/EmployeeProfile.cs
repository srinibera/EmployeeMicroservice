using AutoMapper;
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
			CreateMap<AddEmployeeCommand, Employee>().ReverseMap();
			CreateMap<DeleteEmployeeCommand, Employee>().ReverseMap();
			CreateMap<UpdateEmployeeCommand, Employee>().ReverseMap();
		}
	}
}
