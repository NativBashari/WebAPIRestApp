using Contract.Contracts;
using Repository.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Models;

namespace WebApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public DepartmentsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var departments = unitOfWork.Departments.GetAll();
            return Ok(departments);

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var department = unitOfWork.Departments.Get(id);
            if (department == null) return NotFound();
            else
                return Ok(department);
        }
        [HttpPost]
        public IActionResult PostDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Departments.Create(department);
                unitOfWork.Save();
                return Created("", department);
            }
            else
                return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                var updateDepartment = unitOfWork.Departments.Get(department.DepartmentId);
                updateDepartment.DepartmentName = department.DepartmentName;
                unitOfWork.Save();
                return NoContent();
            }
            else
                return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var department = unitOfWork.Departments.Get(id);
            if (department == null) return NotFound();
            else
            {
                unitOfWork.Departments.Delete(id);
                unitOfWork.Save();
                return NoContent();
            }
        }
    }


}
