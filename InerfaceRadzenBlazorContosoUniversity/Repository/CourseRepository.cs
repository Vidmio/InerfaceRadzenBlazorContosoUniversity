using InerfaceRadzenBlazorContosoUniversity.Model;
using InerfaceRadzenBlazorContosoUniversity.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace InerfaceRadzenBlazorContosoUniversity.Repository
{
    public class CourseRepository : IGenericRepository<Course>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public CourseRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }
        public async Task<List<Course>> Get()
        {
            using var db = await _context.CreateDbContextAsync();
            return await db.Courses.ToListAsync();
        }
        public async Task<Course?> Get(int id)
        {
            using var db = await _context.CreateDbContextAsync();
            return await db.Courses.FirstOrDefaultAsync(a => a.ID == id);
        }

        public bool Add(in Course sender)
        {
            using var db = _context.CreateDbContext();
            db.Entry(sender).State = EntityState.Added;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(in Course sender)
        {
            using var db = _context.CreateDbContext();
            db.Entry(sender).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(in Course sender)
        {
            using var db = _context.CreateDbContext();
            try
            {
                db.Remove(sender);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
