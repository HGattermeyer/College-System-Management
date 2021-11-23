using College_System_Management.Data;
using College_System_Management.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College_System_Management.Services
{
    public class TeacherService
    {
        private readonly College_System_ManagementContext _context;

        public TeacherService(College_System_ManagementContext context)
        {
            _context = context;
        }

        public async Task<List<Teacher>> FindAllAsync() { return await _context.Teacher.ToListAsync(); }

        public async Task<Teacher> FindByIdAsync(int id)
        {
            return await _context.Teacher.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public Teacher FindById(int id)
        {
            return _context.Teacher.FirstOrDefault(obj => obj.Id == id);
        }
    }
}
