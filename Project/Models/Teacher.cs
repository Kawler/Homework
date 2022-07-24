namespace Project.Models
{
    public class Teacher
    {
        public Teacher(int teacherId, string teacherName, string taughtSubject)
        {
            TeacherId = teacherId;
            TeacherName = teacherName;
            TaughtSubject = taughtSubject;
        }

        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TaughtSubject { get; set; }
    }
}
