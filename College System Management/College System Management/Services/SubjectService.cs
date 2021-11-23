using College_System_Management.Data;
using College_System_Management.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College_System_Management.Services
{
    public class SubjectService
    {
        private readonly College_System_ManagementContext _context;

        public SubjectService(College_System_ManagementContext context)
        {
            _context = context;
        }

        public async Task<List<Subject>> FindAllAsync()
        {
            return await _context.Subject.ToListAsync();
        }

        public async Task<Subject> FindByIdAsync(int id)
        {
            return await _context.Subject.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task<List<Subject>> FindByCourseIdAsync(int id)
        {
            return await _context.Subject.Where(obj => obj.CourseId == id).ToListAsync();
        }

        public async Task<List<Subject>> FindAllByCourseIdAsync(int id)
        {
            return await _context.Subject.Where(obj => obj.CourseId == id).ToListAsync();
        }

    }
}
