using System.Data;
using System.Data.SqlClient;

namespace Project.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly string _connectionString;

        public ScheduleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Tuple<string, int, string>> GetSchedule()
        {

        var result = new List<Tuple<string, int, string>>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select ss.[ScheduleId],ss.[SubjectId],s1.[DayOfTheWeek],s1.[ScheduleId],s2.[Classroom],s2.[SubjectId],s2.[SubjectName] from [ScheduleSubject] as ss inner join [Schedule] as s1 on s1.[ScheduleId] = ss.[ScheduleId] inner join [Subjects] as s2 on s2.[SubjectId] =ss.[SubjectId]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Tuple<string, int, string>(
                    Convert.ToString(reader["DayOfTheWeek"]),
                    Convert.ToInt32(reader["Classroom"]),
                    Convert.ToString(reader["SubjectName"])
                ));
            }
            return result;
        }
    }
}
