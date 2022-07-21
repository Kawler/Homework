using Project.Models;

namespace Project.Dto
{
    public static class ScheduleExtension
    {
        public static ScheduleDto ConvertToScheduleDto(this Schedule schedule)
        {
            return new ScheduleDto
            {
                ScheduleId = schedule.ScheduleId,
                DayOfTheWeek = schedule.DayOfTheWeek
            };
        }
    }
}
