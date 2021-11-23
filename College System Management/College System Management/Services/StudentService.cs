using College_System_Management.Data;
using College_System_Management.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College_System_Management.Services
{
    public class StudentService
    {
        private readonly College_System_ManagementContext _context;

        public StudentService(College_System_ManagementContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> FindAllAsync()
        {
            return await _context.Student.ToListAsync();
        }

        public async Task<List<Student>> FindAllByCourseIdAsync(int id)
        {
            return await _context.Student.Where(obj => obj.CourseId == id).Include(g => g.Grades).ToListAsync();
        }

        public async Task<Student> FindByIdAsync(int id)
        {
            return await _context.Student.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
