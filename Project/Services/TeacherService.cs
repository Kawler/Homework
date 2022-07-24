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

        public void Delete(int id)
        {
            _teacherRepository.Delete(id);
        }

        public List<Teacher> GetAll()
        {
            return (List<Teacher>)_teacherRepository.GetAll();
        }

        public void Update(int id,Teacher teacher)
        {
            _teacherRepository.Update(id,teacher);
        }
    }
}
