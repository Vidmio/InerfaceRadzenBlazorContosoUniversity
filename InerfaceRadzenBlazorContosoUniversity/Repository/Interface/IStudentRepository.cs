using InerfaceRadzenBlazorContosoUniversity.Model;
namespace InerfaceRadzenBlazorContosoUniversity.Repository.Interface
{
    public interface IStudentRepository
    {
        public Task <List<Student>> Get();
        public Task<Student?> Get(int id);
        public Task<bool> Update(Student student);
        public Task<bool> Add(Student student);
        public Task<bool> Delete(Student student);
    }
}
