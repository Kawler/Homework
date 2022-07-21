namespace Project.Models
{
    public class Subjects
    {
        public Subjects(int subjectId, int classroom, string subjectName, string photoFile)
        {
            SubjectId = subjectId;
            Classroom = classroom;
            SubjectName = subjectName;
            PhotoFile = photoFile;
        }

        public int SubjectId { get; set; }
        public int Classroom { get; set; }
        public string SubjectName { get; set; }
        public string PhotoFile { get; set; }
    }
}
