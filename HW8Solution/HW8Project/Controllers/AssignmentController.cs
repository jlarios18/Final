using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HW8Project.Models;
using System.Text.Json;

namespace HW8Project.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly AssignmentDbContext _context;

        public AssignmentController(AssignmentDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult AssignmentRequest()
        {
            var assigns = _context.Assignments
                .Include(a => a.Course)
                .Where(a => !a.Completion)
                .OrderBy(a => a.Priority)
                .ToList();

            return Json(assigns);
        }

        //GET: Assignment
        public IActionResult Index()
        {
            var assigns = _context.Assignments
                .Include(a => a.Course)
                .Where(a => !a.Completion)
                .OrderBy(a => a.Priority);


            return View(assigns.ToList());
        }

        // Returns only incomplete assignments
        //POST: Assignment
        [HttpPost, ActionName("Index")]
        public IActionResult Complete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Assignment assignmentToComplete = _context.Assignments.Find(id);

            if (assignmentToComplete == null)
            {
                return NotFound();
            }
            
            assignmentToComplete.Completion = true;

            _context.Assignments.Update(assignmentToComplete);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        //GET: Assignment/Older
        public IActionResult Older()
        {
            var assigns = _context.Assignments
                .Include(a => a.Course)
                .Where(a => a.Completion)
                .OrderBy(a => a.Due);

            return View(assigns.ToList());
        }

        // GET: Assignment/CourseAssignments/5
        public IActionResult CourseAssignments(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = _context.Assignments
                .Include(a => a.Course)
                .Where(a => a.Course.Id == id)
                .OrderBy(a => a.Due);

            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment.ToList());
        }

        // GET: Assignment/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = _context.Assignments
                .FirstOrDefault(m => m.Id == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        //-------------------- Beginning of Create Assign page -------------------------

        // GET: Assignment/Create
        public IActionResult Create()
        {
            ViewBag.CourseId = new SelectList(_context.Courses, "Id", "Name");
            return View();
        }

        // POST: Assignment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Due,Completion,Priority,Notes,CourseId")] Assignment assignment) 
        {
            if (ModelState.IsValid)
            {
                _context.Add(assignment);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CourseId = new SelectList(_context.Courses, "Id", "Name", assignment.CourseId);

            return View(assignment);
        }

        //-------------------- End of Create Assign page -------------------------

        // GET: Assignment/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = _context.Assignments.Find(id);
            if (assignment == null)
            {
                return NotFound();
            }
            return View(assignment);
        }

        // POST: Assignment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Due,Completion,Priority,Notes,CourseId")] Assignment assignment)
        {
            if (id != assignment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignment);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignmentExists(assignment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(assignment);
        }

        // GET: Assignment/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = _context.Assignments
                .FirstOrDefault(m => m.Id == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // POST: Assignment/Delete/5 -- This will help with requirement 2
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var assignment = _context.Assignments.Find(id);
            _context.Assignments.Remove(assignment);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignmentExists(int id)
        {
            return _context.Assignments.Any(e => e.Id == id);
        }
    }
}
