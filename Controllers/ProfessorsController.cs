using Microsoft.AspNetCore.Mvc;
using ProfessorsApi.Models;
using ProfessorsApi.Services;
using System.Collections.Generic;

namespace ProfessorsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        private readonly IProfessorService _professorService;

        public ProfessorsController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Professor>> Get()
        {
            return Ok(_professorService.GetAllProfessors());
        }

        [HttpGet("{id}")]
        public ActionResult<Professor> Get(int id)
        {
            var professor = _professorService.GetProfessorById(id);
            if (professor == null)
                return NotFound();

            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Professor professor)
        {
            _professorService.AddProfessor(professor);
            return CreatedAtAction(nameof(Get), new { id = professor.Id }, professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Professor professor)
        {
            _professorService.UpdateProfessor(id, professor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _professorService.DeleteProfessor(id);
            return NoContent();
        }
    }
}
