using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Models.Models;

namespace Services_.Abstraction
{
    public interface ITaskService
    {
        List<Person> GetPersonsFromFile(IFormFile file);

        Task<List<Person>> GetPersons();

        Task SetPersons(List<Person> persons);

        Task Update(List<Person> persons);

        Task Delete(int id);
    }
}