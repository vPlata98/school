using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using School.Models;

namespace School.Controllers
{
    public class EstudiantesController : Controller
    {
        private ModelSchool _context;

        public EstudiantesController(ModelSchool context){
            this._context = context;
        }

        public IActionResult Index()
        {
            var estudiantes = _context.People
            .Where(c=> c.HireDate == null)
            .ToList();
            return View(estudiantes);
        }

        public IActionResult Ficha(int id)
        {
            var estudiante = _context.People
            .Where(c=> c.PersonID== id)
            .FirstOrDefault();
            return View(estudiante);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ficha(int id, Person person)
        {
            var firstName = ControllerContext.HttpContext.Request.Form["FirstName"];
            
            // return View(person);
            if(id != person.PersonID){
                return NotFound();
            }
            if (ModelState.IsValid){
                _context.Update(person);
                _context.SaveChanges();
                return RedirectToAction("index");
            }else{
                return View(person);  
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
         public IActionResult Nuevo(Person person)
        {
            // return View(person);
            if (ModelState.IsValid){
                _context.Add(person);
                _context.SaveChanges();
                return RedirectToAction("index");
            }else{
                return View("Ficha", new Person()); 
            }
        }

         public IActionResult Nuevo()
        {
        
            return View("Ficha", new Person()); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
