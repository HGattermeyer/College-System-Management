using College_System_Management.Data;
using College_System_Management.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College_System_Management.Services
{
    public class GradeService
    {
        private readonly College_System_ManagementContext _context;
        private readonly SubjectService _subjectService;

        public GradeService(College_System_ManagementContext context, SubjectService subjectService)
        {
            _context = context;
            _subjectService = subjectService;
        }

        public async Task<List<Grade>> FindAllAsync() { return await _context.Grade.ToListAsync(); }

        public async Task<Grade> FindByIdAsync(int id)
        {
            return await _context.Grade.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task InsertGradeByCourse(Student student)
        {
            student.Course.Subjects = await _subjectService.FindByCourseIdAsync(student.Course.Id);

            foreach (var subject in student.Course.Subjects)
            {
                Grade grade = new Grade(0, student, subject);
                _context.Add(grade);
                await _context.SaveChangesAsync();
            }

        }


        public Grade FindById(int id)
        {
            return _context.Grade.FirstOrDefault(obj => obj.Id == id);
        }
    }
}
