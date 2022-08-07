using Contract.Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        readonly IUnitOfWork unitOfWork;
        public PersonsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var list = unitOfWork.Persons.GetAll;
            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Person person = unitOfWork.Persons.Get(id);
            if (person == null) return NotFound();
            else
                return Ok(person);
        }
        [HttpPost]
        public IActionResult PostPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Persons.Create(person);
                unitOfWork.Save();
                return Created("", person);
            }
            else
                return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdatePerson(Person person)
        {
            if (ModelState.IsValid)
            {
                var updatePerson = unitOfWork.Persons.Get(person.Id);
                updatePerson.Name = person.Name;
                updatePerson.Surename = person.Surename;
                updatePerson.Adress = person.Adress;
                updatePerson.Age = person.Age;
                updatePerson.Email = person.Email;
                updatePerson.Password = person.Password;
                updatePerson.PositionId = person.PositionId;
                updatePerson.SalaryId = person.SalaryId;
                unitOfWork.Save();
                return NoContent();
            }
            else
                return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var person = unitOfWork.Persons.Get(id);
            if (person == null) return NotFound();
            else
            {
                unitOfWork.Persons.Delete(id);
                unitOfWork.Save();
                return NoContent();
            }
        }
    }
}
