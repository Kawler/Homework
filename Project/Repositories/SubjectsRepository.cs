using Project.Models;
using System.Data;
using System.Data.SqlClient;

namespace Project.Repositories
{
    public class SubjectsRepository : ISubjectsRepository
    {
        private readonly string _connectionString;

        public SubjectsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Subjects> GetAll()
        {
            var result = new List<Subjects>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [SubjectId], [Classroom], [SubjectName] from [Subjects]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Subjects(
                    Convert.ToInt32(reader["SubjectId"]),
                    Convert.ToInt32(reader["Classroom"]),
                    Convert.ToString(reader["SubjectName"])
                ));
            }

            return result;
        }

        public Subjects GetByName(string subjectName)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [SubjectId], [Classroom], [SubjectName] from [Subjects] where [SubjectName] = @subjectName";
            sqlCommand.Parameters.Add("@subjectName", SqlDbType.NVarChar, 30).Value = subjectName;

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                return new Subjects(
                    Convert.ToInt32(reader["SubjectId"]),
                    Convert.ToInt32(reader["Classroom"]),
                    Convert.ToString(reader["SubjectName"])
                    );
            }
            else
            {
                return null;
            }
        }

        public Subjects GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [SubjectId], [Classroom], [SubjectName] from [Subjects] where [SubjectId] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                return new Subjects(
                    Convert.ToInt32(reader["SubjectId"]),
                    Convert.ToInt32(reader["Classroom"]),
                    Convert.ToString(reader["SubjectName"])
                    );
            }
            else
            {
                return null;
            }
        }

        public void Update(Subjects subjects,int id)
        {
            if (subjects == null)
            {
                throw new ArgumentNullException(nameof(subjects));
            }

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "update [Subjects] set [SubjectName] = @subjectName,[Classroom] = @classroom where [SubjectId] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
            sqlCommand.Parameters.Add("@classroom", SqlDbType.Int).Value = subjects.Classroom;
            sqlCommand.Parameters.Add("@subjectName", SqlDbType.NVarChar, 30).Value = subjects.SubjectName;
            sqlCommand.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "delete [Subjects] where [SubjectId] = @id";
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
            sqlCommand.ExecuteNonQuery();
        }

        public void Create(Subjects subjects)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "insert into [Subjects] (Classroom, SubjectName) values (@classroom, @subjectName)";
            sqlCommand.Parameters.Add("@classroom", SqlDbType.Int).Value = subjects.Classroom;
            sqlCommand.Parameters.Add("@subjectName", SqlDbType.NVarChar, 30).Value = subjects.SubjectName;
            sqlCommand.ExecuteNonQuery();
        }
    }
}
