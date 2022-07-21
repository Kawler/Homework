using Project.Models;
using Project.Repositories;

namespace Project.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public void Create(Teacher teacher)
        {
            _teacherRepository.Create(teacher);
        }

        public void Delete(Teacher teacher)
        {
            _teacherRepository.Delete(teacher);
        }

        public List<Teacher> GetAll()
        {
            return (List<Teacher>)_teacherRepository.GetAll();
        }

        public Teacher GetById(int id)
        {
            return _teacherRepository.GetById(id);
        }

        public Teacher GetByName(string name)
        {
            return _teacherRepository.GetByName(name);
        }

        public List<Tuple<int, string>> GroupByTaughtSubject()
        {
            return (List<Tuple<int, string>>)_teacherRepository.GroupByTaughtSubject();
        }

        public void Update(Teacher teacher)
        {
            _teacherRepository.Update(teacher);
        }
    }
}
