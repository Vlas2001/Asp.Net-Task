using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Repository.Abstraction;

namespace Repository.Implementation
{
    public class TaskRepository: ITaskRepository
    {
        private readonly WorkTaskContext _context;

        public TaskRepository(WorkTaskContext context)
        {
            _context = context;
        }

        public async Task SetAllPersons(List<Person> persons)
        {
            await _context.Users.AddRangeAsync(persons);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Person>> GetAllPersons()
        {
            return await Task.Run(() => _context.Users.ToList());
        }

        public async Task Update(List<Person> persons)
        {
            _context.Users.UpdateRange(persons.ToArray());
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var person = _context.Users.FirstOrDefaultAsync(item => item.Id == id);
            _context.Users.Remove(person.Result);
            await _context.SaveChangesAsync();
        }
    }
}