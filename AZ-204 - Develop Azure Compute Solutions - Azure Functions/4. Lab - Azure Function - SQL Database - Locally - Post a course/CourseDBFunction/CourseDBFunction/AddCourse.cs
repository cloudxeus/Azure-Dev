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
        // This function will be used to add a course
        [FunctionName("AddCourse")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            // First we get the body of the POST request
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            // We then use the JsonConvert class to convert the string of the request body to a Course object
            Course data = JsonConvert.DeserializeObject<Course>(requestBody);

            string _connection_string = "Server=tcp:dbserver10001.database.windows.net,1433;Initial Catalog=appdb;Persist Security Info=False;User ID=demousr;Password=Azure@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            string _statement = "INSERT INTO Course(CourseID,CourseName,rating) VALUES(@param1,@param2,@param3)";
            SqlConnection _connection = new SqlConnection(_connection_string);
            _connection.Open();

            // Here we create a parameterized query to insert the data into the database
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

