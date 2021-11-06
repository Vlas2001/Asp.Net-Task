using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Services_.Abstraction;

namespace WorkTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskService _taskService;

        public HomeController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _taskService.GetPersons());
        }
        
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            await _taskService.SetPersons(_taskService.GetPersonsFromFile(file));
            return View(await _taskService.GetPersons());
        }

        [HttpPost]
        public async Task<IActionResult> Update(List<Person> persons)
        {
            await _taskService.Update(persons);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _taskService.Delete(id);
            return RedirectToAction("Index"); 
        }
    }
}
