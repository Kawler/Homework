namespace Project.Models
{
    public class Subjects
    {
        public Subjects(int subjectId, int classroom, string subjectName)
        {
            SubjectId = subjectId;
            Classroom = classroom;
            SubjectName = subjectName;
        }

        public int SubjectId { get; set; }
        public int Classroom { get; set; }
        public string SubjectName { get; set; }

    }
}
