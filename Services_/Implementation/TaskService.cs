using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Models.Models;
using Repository.Abstraction;
using Services_.Abstraction;

namespace Services_.Implementation
{
    public class TaskService: ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public List<Person> GetPersonsFromFile(IFormFile file)
        {
            var list = new List<Person>();
            using var reader = new StreamReader(file.OpenReadStream());
            using var cswReader = new CsvReader(reader, CultureInfo.InvariantCulture);
            cswReader.Read();
            cswReader.ReadHeader();
            while (cswReader.Read())
            {
                list.Add(cswReader.GetRecord<Person>());
            }
            return list;
        }

        public async Task<List<Person>> GetPersons()
        {
            return await _repository.GetAllPersons();
        }

        public async Task SetPersons(List<Person> persons)
        {
            await _repository.SetAllPersons(persons);
        }

        public async Task Update(List<Person> persons)
        {
            await _repository.Update(persons);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}