using System.Collections.Generic;
using api_rest_test.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using api_rest_test.Domain.Models;
using System.Threading.Tasks;

namespace api_rest_test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> Get()
        {
            return await _personService.SelectAll();
        }

        [HttpGet("{id}")]
        public async Task<Person> Get(int id)
        {
            return await _personService.SelectOne(id);
        }
        /*
        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        { 
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {   
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {  
        }
        */
    }
}
