using Project.Models;

namespace Project.Repositories
{
    public interface ITeacherRepository
    {
        List<Teacher> GetAll();
        Teacher GetByName(string name);
        Teacher GetById(int id);
        void Delete(Teacher teacher);
        List<Tuple<int, string>> GroupByTaughtSubject();
        void Create(Teacher teacher);
        void Update(Teacher teacher);
    }
}
