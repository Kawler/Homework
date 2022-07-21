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
            sqlCommand.CommandText = "select [TeacherId], [TeacherName], [TaughtSubject], [PhotoFile] from [Teacher]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Teacher(
                    Convert.ToInt32(reader["TeacherId"]),
                    Convert.ToString(reader["TeacherName"]),
                    Convert.ToString(reader["TaughtSubject"]),
                    Convert.ToString(reader["PhotoFile"])
                ));
            }

            return result;
        }

        public Teacher GetByName(string teacherName)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [TeacherId], [TeacherName], [TaughtSubject], [PhotoFile] from [Teacher] where [TeachersName] = @teacherName";
            sqlCommand.Parameters.Add("@teacherName", SqlDbType.NVarChar, 50).Value = teacherName;

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                return new Teacher(
                    Convert.ToInt32(reader["TeacherId"]),
                    Convert.ToString(reader["TeacherName"]),
                    Convert.ToString(reader["TaughtSubject"]),
                    Convert.ToString(reader["PhotoFile"]));
            }
            else
            {
                return null;
            }
        }

        public void Delete(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "delete [Teacher] where [TeacherId] = @teacherId";
            sqlCommand.Parameters.Add("@teacherId", SqlDbType.Int).Value = teacher.TeacherId;
            sqlCommand.ExecuteNonQuery();
        }

        public List<Tuple<int, string>> GroupByTaughtSubject()
        {
            var result = new List<Tuple<int, string>>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select count([TeacherId]) c, [TaughtSubject] from [Teacher] group by [TaughtSubject]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Tuple<int, string>(
                    Convert.ToInt32(reader["c"]),
                    Convert.ToString(reader["TaughtSubject"])
                ));
            }

            return result;
        }

        public void Update(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "update [Teacher] set [TeacherName] = @teacherName where [TeacherId] = @teacherId";
            using SqlCommand sqlCommand2 = connection.CreateCommand();
            sqlCommand.CommandText = "update [Teacher] set [TaughtSubject] = @taughtSubject where [TeacherId] = @teacherId";
            using SqlCommand sqlCommand3 = connection.CreateCommand();
            sqlCommand.CommandText = "update [Teacher] set [PhotoFile] = @photoFile where [TeacherId] = @teacherId";
            sqlCommand.Parameters.Add("@teacherId", SqlDbType.Int).Value = teacher.TeacherId;
            sqlCommand.Parameters.Add("@teacherName", SqlDbType.NVarChar, 50).Value = teacher.TeacherName;
            sqlCommand.Parameters.Add("@taughtSubject", SqlDbType.NVarChar, 30).Value = teacher.TaughtSubject;
            sqlCommand.Parameters.Add("@photoFile", SqlDbType.NVarChar, 500).Value = teacher.PhotoFile;
            sqlCommand.ExecuteNonQuery();
        }

        public void Create(Teacher teacher)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "insert into [Teacher] (TeacherName, TaughtSubject, PhotoFile) values (@teacherName, @taughtSubject, @photoFile)";
            sqlCommand.Parameters.Add("@teacherName", SqlDbType.NVarChar, 50).Value = teacher.TeacherName;
            sqlCommand.Parameters.Add("@taughtSubject", SqlDbType.NVarChar, 30).Value = teacher.TaughtSubject;
            sqlCommand.Parameters.Add("@photoFile", SqlDbType.NVarChar, 500).Value = teacher.PhotoFile;
            sqlCommand.ExecuteNonQuery();
        }

        public Teacher GetById(int teacherId)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [TeacherId], [TeacherName], [TaughtSubject], [PhotoFile] from [Teacher] where [TeacherId] = @teacherId";
            sqlCommand.Parameters.Add("@teacherId", SqlDbType.Int).Value = teacherId;

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                return new Teacher(
                    Convert.ToInt32(reader["TeacherId"]),
                    Convert.ToString(reader["TeacherName"]),
                    Convert.ToString(reader["TaughtSubject"]),
                    Convert.ToString(reader["PhotoFile"]));
            }
            else
            {
                return null;
            }
        }
    }
}
