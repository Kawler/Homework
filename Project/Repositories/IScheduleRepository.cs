using Project.Models;

namespace Project.Repositories
{
    public interface IScheduleRepository
    {
        List<Tuple<string, int, string>> GetSchedule();
    }
}
