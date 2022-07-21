namespace Project.Models
{
    public class ScheduleSubject
    {
        public ScheduleSubject(int scheduleSubjectId, int scheduleId, int subjectId)
        {
            ScheduleSubjectId = scheduleSubjectId;
            ScheduleId = scheduleId;
            SubjectId = subjectId;
        }

        public int ScheduleSubjectId { get; set; }
        public int ScheduleId { get; set; }
        public int SubjectId { get; set; }
    }
}
