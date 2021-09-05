using AutoMapper;
using EmployeeService.API.DTO;
using EmployeeService.API.Features.Employee.Commands;
using EmployeeService.Domain;
using EmployeeService.Features.Employee.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EmployeeService.API.Controllers
{    
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeeController : ControllerBase    
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMediator _mediator;        
        public EmployeeController(IMediator mediator, ILogger<EmployeeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

                     
        [HttpGet]
        [Route("")]
        [Route("All")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(EmployeeDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> Get()
        {            
            var query = new GetEmployeeListQuery();
            var employee = await _mediator.Send(query);
          
            _logger.LogInformation($" Get all employees.");

            return Ok(employee.OrderBy(e => e.FirstName));

        }

        [HttpGet]        
        [Route("Status/{employeeId}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(EmployeeDTO), (int)HttpStatusCode.OK)]
        public async Task<string> GetEmployeeStatus(long employeeId)
        {
            var query = new GetEmployeeStatusQuery(employeeId);
            var employee = await _mediator.Send(query);

            _logger.LogInformation($" Get by employee id.");
            return employee;

        }

        [HttpGet]
        [Route("Search/{employeeId}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(EmployeeDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetByEmployeeId(long employeeId)
        {
            var query = new GetEmployeeQuery(employeeId);
            var employee = await _mediator.Send(query);
            _logger.LogInformation($" search on employee id {employeeId}");
            return Ok(employee);

        }

        [HttpPost()]
        [Route("Search")]        
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(EmployeeDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> SearchEmployee([FromBody]EmployeeDTO employee)
        {
            var query = new GetEmployeesFilterQuery(employee);
            var filterData = await _mediator.Send(query);
            return Ok(filterData);

        }

        [HttpPost(Name = "AddEmployee")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> AddEmployee([FromBody] CreateEmployee command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateEmployee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateEmployee([FromBody] UpdateEmployee command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteEmployee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var command = new DeleteEmployee() { EmployeeId = id };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
