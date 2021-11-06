using System.Collections.Generic;
using Task.Models;

namespace Services
{
    public interface ITaskService
    {
        List<Person> GetPersons(string fileName);
    }
}