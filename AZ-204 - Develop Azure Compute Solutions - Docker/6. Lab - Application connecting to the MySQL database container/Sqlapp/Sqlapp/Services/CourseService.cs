using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Sqlapp.Models;
using MySql.Data.MySqlClient;

namespace Sqlapp.Services
{
    public class CourseService
    {
        // Ensure to change the below variables to reflect the connection details for your database

        private static string db_connectionstring= "server=mysqlserver10001.mysql.database.azure.com;user=sqlusr@mysqlserver10001;password=Azure123;database=appdb";
        
        private MySqlConnection GetConnection()
        {
            // Here we are creating the SQL connection
            
            return new MySqlConnection(db_connectionstring);
        }

        public IEnumerable<Course> GetCourses()
        {
            List<Course> _lst = new List<Course>();
            string _statement = "SELECT CourseID,CourseName,rating from Course;";
            MySqlConnection _connection = GetConnection();
            // Let's open the connection
            _connection.Open();

            MySqlCommand _sqlcommand = new MySqlCommand(_statement,_connection);

            using (MySqlDataReader _reader = _sqlcommand.ExecuteReader())
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
            }
            _connection.Close();
            return _lst;
        }

    }
    }

    

