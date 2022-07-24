namespace Project.Services
{
    public interface IScheduleService
    {
        List<Tuple<string, int, string>> GetSchedule();
    }
}
