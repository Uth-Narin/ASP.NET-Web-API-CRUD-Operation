using EmployeeAdminePortail.Data;
using EmployeeAdminePortail.Models;
using EmployeeAdminePortail.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
namespace EmployeeAdminePortail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDBContextcs dbContext;

        public EmployeesController(ApplicationDBContextcs dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = dbContext.Employees.ToList();
            return Ok(allEmployees);
        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee is null)
            {
                return NotFound();
            }
            return Ok(employee);

        }
        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDtocs addEmployeeDtocs)
        {
            var employeeEntity = new Employee()
            {
                Name = addEmployeeDtocs.Name,
                Email = addEmployeeDtocs.Email,
                Phone = addEmployeeDtocs.Phone,
                Salary = addEmployeeDtocs.Salary,

            };
            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();

            return Ok(employeeEntity);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee is null)
            {
                return NotFound();
            }
            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;
            dbContext.SaveChanges();

            return Ok(employee);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = dbContext.Employees.Find(id);    
            if (employee is null)
            {
                return NotFound();
            }
            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();

            return Ok(employee);
        }
    }
}