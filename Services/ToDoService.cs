using System.Runtime.CompilerServices;
using ToDo.Data;
using ToDo.Models;
using ToDo.Models.Enum;
using Microsoft.EntityFrameworkCore;
namespace ToDo.Services
{
    public class ToDoService
    {
        private readonly ToDoContext _context;

        public ToDoService(ToDoContext context)
        {
            _context = context;
        }

        public async Task<List<ToDoList>> FindByAllAsync(DateTime? minDate, DateTime? maxDate, Status? status)
        {
            var result = _context.ToDoList.AsQueryable();


            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            if (status.HasValue)
            {
                result = result.Where(x => x.Status == status);
            }

            return await result
                        .OrderByDescending(x => x.Date)
                        .ToListAsync();
        }

        public async Task<List<ToDoList>> FindByStatusAsync(Status? status)
        {
            var result = from obj in _context.ToDoList select obj;

            result = result.Where(x => x.Status == status);
            

            return await result
                        .ToListAsync();
        }

    }
}
