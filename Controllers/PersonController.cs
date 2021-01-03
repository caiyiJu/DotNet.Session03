using DotNet.Session03.Models;
using DotNet.Session03.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.Session03.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;
        public PersonController(PersonDbContext personDbContext)
        {
            _personService = new PersonService(personDbContext);
        }


        // GET api/Person
        [HttpGet]
        public IActionResult Get()
        {
            var people = _personService.GetAll();
            return Ok(people);
        }

        // GET api/Person/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personService.GetBy(id);
            if (person == null)
                return NotFound();
            return Ok(person);
        }

        // POST api/Person
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var personId = _personService.Create(person);
            return Ok(personId);
        }


        // DELETE api/Person/5
        [HttpDelete("{id}")]
        public IActionResult SoftDelete(int id)
        {
            _personService.SoftDelete(id);
            return Ok();
        }
        // DELETE api/Person/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
            return Ok();
        }
    }
}

