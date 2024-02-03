using InerfaceRadzenBlazorContosoUniversity.Model;
using InerfaceRadzenBlazorContosoUniversity.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace InerfaceRadzenBlazorContosoUniversity.Repository
{
    public class StudentRepository : IGenericRepository<Student>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public StudentRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
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

        public bool Add(in Student sender)
        {
            using var db =_context.CreateDbContext();
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
        public bool Update(in Student sender)
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
        public bool Delete(in Student sender)
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
