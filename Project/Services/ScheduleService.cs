using Project.Models;
using Project.Repositories;

namespace Project.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }
        public List<Tuple<string, int, string>> GetSchedule()
        {
            return(List<Tuple<string, int, string>>) _scheduleRepository.GetSchedule();   
        }
    }
}
