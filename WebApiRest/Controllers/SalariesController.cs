using Contract.Contracts;
using Entities.Models;
using Repository.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalariesController : ControllerBase
    {
        IUnitOfWork unitOfWork;
        public SalariesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var list = unitOfWork.Salaries.GetAll();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var salary = unitOfWork.Salaries.Get(id);
            if (salary == null) return NotFound();
            else
                return Ok(salary);
        }
        [HttpPost]
        public IActionResult PostSalary(Salary salary)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Salaries.Create(salary);
                unitOfWork.Save();
                return Created("", salary);
            }
            else return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdatePosition(Salary salary)
        {
            if (ModelState.IsValid)
            {
                var updateSalary = unitOfWork.Salaries.Get(salary.SalaryId);
                updateSalary.Amount = salary.Amount;

                unitOfWork.Save();
                return NoContent();
            }
            else
                return BadRequest();

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Salary salary = unitOfWork.Salaries.Get(id);
            if (salary == null) return NotFound();
            else
            {
                unitOfWork.Salaries.Delete(id);
                unitOfWork.Save();
                return NoContent();
            }
        }
    }
}
