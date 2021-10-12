using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Sqlapp.Models;
using System.Configuration;
using System.Text;
using StackExchange.Redis;
using System.Text.Json;

namespace Sqlapp.Services
{
    public class CourseService
    {
        private static Lazy<ConnectionMultiplexer> cache_connection = CreateConnection();

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return cache_connection.Value;
            }
        }

        private static Lazy<ConnectionMultiplexer> CreateConnection()
        {
            string cache_connectionstring = "newcache1000.redis.cache.windows.net:6380,password=lSpWcGeFeXDojdbJZtrMdISlVmyUhsIPDXTaMvZ0m1g=,ssl=True,abortConnect=False";
            return new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect(cache_connectionstring);
            });
        }
        private SqlConnection GetConnection(string _connection_string)
        {
            // Here we are creating the SQL connection
            return new SqlConnection(_connection_string);
        }

        public IEnumerable<Course> GetCourses(string _connection_string)
        {
            List<Course> _lst = new List<Course>();

            IDatabase cache = Connection.GetDatabase();
            if (cache.KeyExists("Course"))
            {
                _lst = JsonSerializer.Deserialize<List<Course>>(cache.StringGet("Course"));
                return _lst;
            }
            else 
            {
                string _statement = "SELECT CourseID,CourseName,rating from Course";
                SqlConnection _connection = GetConnection(_connection_string);
                // Let's open the connection
                _connection.Open();
                // We then construct the statement of getting the data from the Course table
                SqlCommand _sqlcommand = new SqlCommand(_statement, _connection);
                // Using the SqlDataReader class , we will read all the data from the Course table
                using (SqlDataReader _reader = _sqlcommand.ExecuteReader())
                {
                    while (_reader.Read())
                    {
                        Course _course = new Course()
                        {
                            CourseID = _reader.GetInt32(0),
                            CourseName = _reader.GetString(1),
                            Rating = _reader.GetDecimal(2)
                        };

                        _lst.Add(_course);
                    }
                    cache.StringSet("Course", JsonSerializer.Serialize<List<Course>>(_lst));
                }
                _connection.Close();
                return _lst;

            }
            
        }

        public void UpdateCourse(Course p_course, string _connection_string)
        {
             StringBuilder _statement = new StringBuilder("UPDATE Course SET Rating=");
            _statement.Append(p_course.Rating);
            _statement.Append(" WHERE CourseID=");
            _statement.Append(p_course.CourseID);

            SqlConnection _connection = GetConnection(_connection_string);
            // Let's open the connection
            _connection.Open();
            // We then construct the statement of getting the data from the Course table
            SqlCommand _sqlcommand = new SqlCommand(_statement.ToString(), _connection);
            _sqlcommand.ExecuteNonQuery();

        }

        public Course GetCourse(string id, string _connection_string)
        {
            IEnumerable<Course> _courses = this.GetCourses(_connection_string);
            Course _course = _courses.FirstOrDefault(m => m.CourseID == Int32.Parse(id));
            return _course;
        }

    }
    }

    

