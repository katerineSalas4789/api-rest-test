using System.Collections.Generic;
using System.Threading.Tasks;
using api_rest_test.Domain.Models;
using api_rest_test.Domain.Repositories.Interfaces;
using api_rest_test.Domain.Services.Interfaces;

namespace api_rest_test.Domain.Services
{
    public class PersonService : IPersonService
    {

        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IEnumerable<Person>> SelectAll()
        {
            return await _personRepository.SelectAll();
        }

        public async Task<Person> SelectOne(int id)
        {
            return await _personRepository.SelectOne(id);
        }

    }
}
