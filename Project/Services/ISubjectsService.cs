using Project.Models;

namespace Project.Services
{
    public interface ISubjectsService
    {
        List<Subjects> GetAll();
        Subjects GetById(int id);
        Subjects GetByName(string name);
        void Update(Subjects subjects, int id);
        void Delete(int id);
        void Create(Subjects subjects);
    }
}
