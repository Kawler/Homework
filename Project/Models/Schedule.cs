namespace Project.Models
{
    public class Schedule
    {
        public Schedule (int scheduleId,string dayOfTheWeek)
        {
            ScheduleId = scheduleId;
            DayOfTheWeek = dayOfTheWeek;
        }
        public int ScheduleId { get; set; }
        public string DayOfTheWeek { get; set; }
    }
}
