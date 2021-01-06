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
        [ValidateAntiForgeryToken]
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

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0 )
            {
                return NotFound();
            }

            var job = _context.Job.Find(Id);
            //if (job == null)
            //{
            //    return NotFound();
            //}

            return View(job);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Job Job)
        {
            if (ModelState.IsValid)
            {
                _context.Update(Job);
                _context.SaveChanges();
                TempData["message"] = "Job Record Edited";
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var job = _context.Job.Find(Id);
            //if (job == null)
            //{
            //    return NotFound();
            //}

            return View(job);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteJob(int? Id)
        {

            var job = _context.Job.Find(Id);

                _context.Remove(job);
                _context.SaveChanges();
                TempData["message"] = "Job Record Deleted";
                return RedirectToAction("Index");
         }




    }
}
