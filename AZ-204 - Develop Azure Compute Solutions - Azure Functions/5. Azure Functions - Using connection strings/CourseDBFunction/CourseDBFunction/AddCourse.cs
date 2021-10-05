using System;
using System.Data;
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
    public static class AddCourse
    {
        [FunctionName("AddCourse")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Course data = JsonConvert.DeserializeObject<Course>(requestBody);
            // Ensure to use the Environment class to get the connection string
            string _connection_string = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_SQLConnectionString");
            string _statement = "INSERT INTO Course(CourseID,CourseName,rating) VALUES(@param1,@param2,@param3)";
            SqlConnection _connection = new SqlConnection(_connection_string);
            _connection.Open();

            using(SqlCommand _command= new SqlCommand(_statement,_connection))
            {
                _command.Parameters.Add("@param1",SqlDbType.Int).Value= data.CourseID;
                _command.Parameters.Add("@param2", SqlDbType.VarChar, 1000).Value = data.CourseName;
                _command.Parameters.Add("@param3", SqlDbType.Decimal).Value = data.Rating;
                _command.CommandType = CommandType.Text;
                _command.ExecuteNonQuery();

            }

            return new OkObjectResult("Course added");
        }
    }
}

