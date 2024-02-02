using InerfaceRadzenBlazorContosoUniversity.Model;
using InerfaceRadzenBlazorContosoUniversity.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace InerfaceRadzenBlazorContosoUniversity.Repository
{
    public class EnrollmentRepository : IGenericRepository<Enrollment>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        public EnrollmentRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }

        public async Task<List<Enrollment>> Get()
        {
            using var db = await _context.CreateDbContextAsync();
            return await db.Enrollments.Include("Student").Include("Course").ToListAsync();
        }
        public async Task<Enrollment?> Get(int id)
        {
            using var db = await _context.CreateDbContextAsync();
            return await db.Enrollments.FirstOrDefaultAsync(a => a.ID == id);
        }

        public bool Add(in Enrollment sender)
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
        public bool Update(in Enrollment sender)
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
        public bool Delete(in Enrollment sender)
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
        //public bool Update(in Enlistment sender)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
