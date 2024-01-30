using InerfaceRadzenBlazorContosoUniversity.Model;
using InerfaceRadzenBlazorContosoUniversity.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace InerfaceRadzenBlazorContosoUniversity.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public StudentRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<bool> Add(Student obj)
        {
            using var db = await _context.CreateDbContextAsync();
            await db.Students.AddAsync(obj);
            try
            {
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Student>> Get()
        {
            using var db = await _context.CreateDbContextAsync();
            return await db.Students.ToListAsync();
        }

        public async Task<Student?> Get(int id)
        {
            using var db = await _context.CreateDbContextAsync();
            return await db.Students.FirstOrDefaultAsync(a => a.ID == id);
        }

        public async Task<bool> Update(Student obj)
        {
            using var db = await _context.CreateDbContextAsync();
            db.Entry(obj).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(Student obj)
        {
            using var db = await _context.CreateDbContextAsync();
            try
            {
                db.Remove(obj);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
