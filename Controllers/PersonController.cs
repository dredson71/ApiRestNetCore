using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectApi.Models;
using System.Data;

namespace ProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context){
            _context=context;
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetPersonItem(int id)
        {
            var personItem = _context.Persons.Find(id);
            if(personItem ==  null){
                return NotFound();
            }
            return personItem;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetPersons()
        {
            return _context.Persons;
        }

        [HttpPost]
        public ActionResult<Person> PostPersonItem(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
            return CreatedAtAction("GetPersonItem",new Person{Id = person.Id},person);
        }

        [HttpPut("{id}")]
        public ActionResult  PutPersonItem(int id,Person person)
        {
            if(id != person.Id){
                return BadRequest();
            }
            _context.Entry(person).State =  EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

         [HttpDelete("{id}")]
        public ActionResult<Person>  DeletePersonItem(int id)
        {
            var personItem = _context.Persons.Find(id);
            if(personItem == null){
                return NotFound();
            }
            _context.Persons.Remove(personItem);
            _context.SaveChanges();
            return personItem;
        }
    }
}