namespace Project.Models
{
    public class Teacher
    {
        public Teacher(int teacherId, string teacherName, string taughtSubject, string photoFile)
        {
            TeacherId = teacherId;
            TeacherName = teacherName;
            TaughtSubject = taughtSubject;
            PhotoFile = photoFile;
        }

        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TaughtSubject { get; set; }
        public string PhotoFile { get; set; }
    }
}
