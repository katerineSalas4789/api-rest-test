using System.Collections.Generic;
using System.Threading.Tasks;
using api_rest_test.Domain.Models;

namespace api_rest_test.Domain.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> SelectAll();
        Task<Person> SelectOne(int id);
    }
}
