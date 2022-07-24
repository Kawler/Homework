using Project.Repositories;
using Project.Models;


namespace Project.Services
{
    public class SubjectsService : ISubjectsService
    {
        private readonly ISubjectsRepository _subjectsRepository;
        public SubjectsService(ISubjectsRepository subjectsRepository)
        {
            _subjectsRepository = subjectsRepository;
        }

        public void Create(Subjects subjects)
        {
            _subjectsRepository.Create(subjects);
        }

        public void Delete(int id)
        {
            _subjectsRepository.Delete(id);
        }

        public List<Subjects> GetAll()
        {
            return (List<Subjects>)_subjectsRepository.GetAll();
        }

        public Subjects GetById(int id)
        {
            return _subjectsRepository.GetById(id);
        }

        public Subjects GetByName(string name)
        {
            return _subjectsRepository.GetByName(name);
        }

        public void Update(Subjects subjects, int id)
        {
            _subjectsRepository.Update(subjects,id);
        }
    }
}
