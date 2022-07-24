using Project.Models;

namespace Project.Dto
{
    public static class TeacherExtension
    {
        public static TeacherDto ConvertToTeacherDto(this Teacher teacher)
        {
            return new TeacherDto
            {
                TeacherId = teacher.TeacherId,
                TeacherName = teacher.TeacherName,
                TaughtSubject = teacher.TaughtSubject
            };
        }
    }
}
