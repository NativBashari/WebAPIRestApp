using Contract.Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {

        IUnitOfWork unitOfWork;
        public PositionsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var positions = unitOfWork.Positions.GetAll();
            return Ok(positions);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var position = unitOfWork.Positions.Get(id);
            if (position == null) return NotFound();
            else
                return Ok(position);
        }
        [HttpPost]
        public IActionResult PostPosition(Position position)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Positions.Create(position);
                unitOfWork.Save();
                return Created("", position);

            }
            else
                return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdatePosition(Position position)
        {
            if (ModelState.IsValid)
            {
                var updatePosition = unitOfWork.Positions.Get(position.Id);
                updatePosition.Name = position.Name;
                updatePosition.DepartmentId = position.DepartmentId;
                unitOfWork.Save();
                return NoContent();
            }
            else
                return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var position = unitOfWork.Positions.Get(id);
            if (position == null) return NotFound();
            else
            {
                unitOfWork.Positions.Delete(id);
                unitOfWork.Save();
                return NoContent();
            }
        }
    }
}
