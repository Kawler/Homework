using Project.Models;

namespace Project.Repositories
{
    public interface ISubjectsRepository
    {
        List<Subjects> GetAll();
        Subjects GetById(int id);
        Subjects GetByName(string name);
        void Update(Subjects subjects);
        void Delete(Subjects subjects);
        void Create(Subjects subjects);
    }
}
