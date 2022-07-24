using Project.Models;

namespace Project.Services
{
    public interface ITeacherService
    {
        List<Teacher> GetAll();
        void Delete(int id);
        void Create(Teacher teacher);
        void Update(int id,Teacher teacher);
    }
}
