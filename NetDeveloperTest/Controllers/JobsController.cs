using Microsoft.AspNetCore.Mvc;
using NetDeveloperTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetDeveloperTest.Controllers
{
    public class JobsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public IActionResult Index()
        {
            return View();
        }
    }
}
