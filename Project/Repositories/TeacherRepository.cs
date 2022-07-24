using System.Data;
using System.Data.SqlClient;
using Project.Models;

namespace Project.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly string _connectionString;

        public TeacherRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Teacher> GetAll()
        {
            var result = new List<Teacher>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select t.[TeacherId], t.[TeacherName], t.[TaughtSubject],s.[SubjectId],s.[SubjectName] from [Teacher] as t inner join[Subjects] as s on s.[SubjectId] = t.[TaughtSubject]";
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Teacher(
                    Convert.ToInt32(reader["TeacherId"]),
                    Convert.ToString(reader["TeacherName"]),
                    Convert.ToString(reader["SubjectName"])
                ));
            }

            return result;
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "delete [Teacher] where [TeacherId] = @teacherId";
            sqlCommand.Parameters.Add("@teacherId", SqlDbType.Int).Value = id;
            sqlCommand.ExecuteNonQuery();
        }

        public void Update(int id, Teacher teacher)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "update [Teacher] set [TeacherName] = @teacherName, [TaughtSubject] = @taughtSubject where [TeacherId] = @teacherId";
            sqlCommand.Parameters.Add("@teacherId", SqlDbType.Int).Value = id;
            sqlCommand.Parameters.Add("@teacherName", SqlDbType.NVarChar, 50).Value = teacher.TeacherName;
            sqlCommand.Parameters.Add("@taughtSubject", SqlDbType.NVarChar, 30).Value = Convert.ToString(subjectId);
            sqlCommand.ExecuteNonQuery();
        }

        public void Create(Teacher teacher)
        {
            int id=Find(teacher);
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "insert into [Teacher] (TeacherName, TaughtSubject) values (@teacherName, @taughtSubject)";
            sqlCommand.Parameters.Add("@teacherName", SqlDbType.NVarChar, 50).Value = teacher.TeacherName;
            sqlCommand.Parameters.Add("@taughtSubject", SqlDbType.NVarChar, 30).Value = Convert.ToString(id);
            sqlCommand.ExecuteNonQuery();
        }

        public int Find(Teacher teacher)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            int result = 0; 
            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [SubjectId],[SubjectName] from [Subjects] where [SubjectName] = @taughtSubject";
            sqlCommand.Parameters.Add("@taughtSubject", SqlDbType.NVarChar, 30).Value = teacher.TaughtSubject;
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result = Convert.ToInt32(reader["SubjectId"]);
            }
            return result;
        }

    }
}
