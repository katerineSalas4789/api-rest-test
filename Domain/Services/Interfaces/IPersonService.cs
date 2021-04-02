using api_rest_test.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_rest_test.Domain.Services.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> SelectAll();
        Task<Person> SelectOne(int id);
    }
}
