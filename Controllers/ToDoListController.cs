using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Data;
using ToDo.Models;
using ToDo.Models.Enum;
using ToDo.Services;

namespace ToDo.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly ToDoContext _context;
        private readonly ToDoService _toDoService;

        public ToDoListController(ToDoContext context, ToDoService toDoService)
        {
            _context = context;
            _toDoService = toDoService;
        }

        // GET: ToDoLists
        [HttpGet]
        public async Task<IActionResult> Index(DateTime? minDate, DateTime? maxDate, Status? status)
        {

            
            if (minDate.HasValue && maxDate.HasValue)
            {
                ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
                ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");              
            }
            var result = await _toDoService.FindByAllAsync(minDate, maxDate, status);

            return View(result);
        }


        // GET: ToDoLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoList = await _context.ToDoList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDoList == null)
            {
                return NotFound();
            }

            return View(toDoList);
        }

        // GET: ToDoLists/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Title,Description,Status")] ToDoList toDoList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toDoList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toDoList);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoList = await _context.ToDoList.FindAsync(id);
            if (toDoList == null)
            {
                return NotFound();
            }
            return View(toDoList);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Title,Description,Status")] ToDoList toDoList)
        {
            if (id != toDoList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDoList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoListExists(toDoList.Id))
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
            return View(toDoList);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoList = await _context.ToDoList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDoList == null)
            {
                return NotFound();
            }

            return View(toDoList);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toDoList = await _context.ToDoList.FindAsync(id);
            if (toDoList != null)
            {
                _context.ToDoList.Remove(toDoList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToDoListExists(int id)
        {
            return _context.ToDoList.Any(e => e.Id == id);
        }

    }
}
