using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using Task.Models;

namespace Services
{
    public class TaskService: ITaskService
    {
        public List<Person> GetPersons(string fileName)
        {
            var list = new List<Person>();
            using var reader = new StreamReader(fileName);
            using var cswReader = new CsvReader(reader, CultureInfo.InvariantCulture);
            cswReader.Read();
            cswReader.ReadHeader();
            while (cswReader.Read())
            {
                list.Add(cswReader.GetRecord<Person>());
            }
            return list;
        }
    }
}