using Project.Models;

namespace Project.Dto
{
    public static class ScheduleSubjectExtension
    {
        public static ScheduleSubjectDto ConvertToScheduleSubjectDto(this ScheduleSubject scheduleSubject)
        {
            return new ScheduleSubjectDto
            {
                ScheduleSubjectId = scheduleSubject.ScheduleSubjectId,
                ScheduleId = scheduleSubject.ScheduleId,
                SubjectId = scheduleSubject.SubjectId
            };
        }
    }
}
