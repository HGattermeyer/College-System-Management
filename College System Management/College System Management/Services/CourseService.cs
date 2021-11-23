using College_System_Management.Data;
using College_System_Management.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College_System_Management.Services
{
    public class CourseService
    {
        private readonly College_System_ManagementContext _context;

        public CourseService(College_System_ManagementContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> FindAllAsync()
        {
            return await _context.Course.ToListAsync();

        }

        public async Task<Course> FindByIdAsync(int id) => await _context.Course.
                Include(s => s.Students).ThenInclude(g => g.Grades).
                Include(u => u.Subjects).ThenInclude(t => t.Teacher).
                Where(x => x.Id == id).SingleOrDefaultAsync();

        //public async Task<Course> FindByIdAsync(int id) => await _context.Course.
        //Include(s => s.Students).ThenInclude(g => g.Grades).
        //Include(u => u.Subjects).ThenInclude(x => x.Id).
        //FirstOrDefaultAsync(obj => obj.Id == id);


        public Course FindById(int id)
        {
            return _context.Course.FirstOrDefault(obj => obj.Id == id);
        }

    }
}
