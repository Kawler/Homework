using Project.Models;

namespace Project.Repositories
{
    public interface ITeacherRepository
    {
        List<Teacher> GetAll();
        void Delete(int id);
        void Create(Teacher teacher);
        void Update(int id,Teacher teacher);
        int Find(Teacher teacher);
    }
}
