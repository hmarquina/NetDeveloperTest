using Microsoft.AspNetCore.Mvc;
using NetDeveloperTest.Data;
using NetDeveloperTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetDeveloperTest.Controllers
{
    public class JobsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public JobsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Job> listJobs = _context.Job;
            return View(listJobs);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Job Job)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Job);
                _context.SaveChanges();
                TempData["message"] = "Job Record Created";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
