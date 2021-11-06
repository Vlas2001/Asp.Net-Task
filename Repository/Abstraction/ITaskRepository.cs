using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Models;

namespace Repository.Abstraction
{
    public interface ITaskRepository
    {
        Task SetAllPersons(List<Person> persons);

        Task<List<Person>> GetAllPersons();

        Task Update(List<Person> persons);

        Task Delete(int id);
    }
}