using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using HW8Project.Models;

namespace HW8Project.Controllers
{
    public class HomeController : Controller
    {
        //---------------Testing---------------------
        private readonly AssignmentDbContext _context;

        public HomeController(AssignmentDbContext context)
        {
            _context = context;
        }
        //-------------------------------------------

        // GET: Home
        public ActionResult Index()
        {
            var assigns = _context.Assignments
                .Include(i => i.Course)
                .OrderByDescending(a => a.Name);

            Debug.WriteLine(assigns.ToList());
            return View(assigns.ToList());
        }
        //----------------------------------------- Not using the code below ---------------------------------------------------

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

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
