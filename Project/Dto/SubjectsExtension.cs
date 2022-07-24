using Project.Models;

namespace Project.Dto
{
    public static class SubjectsExtension
    {
        public static SubjectsDto ConvertToSubjectsDto(this Subjects subjects)
        {
            return new SubjectsDto
            {
                SubjectId = subjects.SubjectId,
                Classroom = subjects.Classroom,
                SubjectName = subjects.SubjectName
            };
        }
    }
}
