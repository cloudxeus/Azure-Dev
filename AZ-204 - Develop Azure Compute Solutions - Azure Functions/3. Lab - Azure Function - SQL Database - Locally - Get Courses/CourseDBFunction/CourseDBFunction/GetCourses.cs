using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CourseDBFunction
{
    public static class GetCourses
    {
        // This function is used to get the list of courses
        [FunctionName("GetCourses")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get",Route = null)] HttpRequest req,
            ILogger log)
        {
            List<Course> _lst = new List<Course>();

            string _connection_string = "Server=tcp:dbserver10001.database.windows.net,1433;Initial Catalog=appdb;Persist Security Info=False;User ID=demousr;Password=Azure@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            string _statement = "SELECT CourseID,CourseName,rating from Course";
            // We first establish a connection to the database
            SqlConnection _connection = new SqlConnection(_connection_string);
            _connection.Open();

            SqlCommand _sqlcommand = new SqlCommand(_statement, _connection);
            // Using the SqlDataReader class , we can get all the rows from the table
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
            }
            _connection.Close();      
            // Return the HTTP status code of 200 OK and the list of courses
            return new OkObjectResult(_lst);
        }
    }
}

