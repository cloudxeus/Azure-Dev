using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Sqlapp.Models;
using System.Configuration;
using System.Net.Http;
using System.Text.Json;

namespace Sqlapp.Services
{
    public class CourseService
    {
        private static string db_source = "dbserver10001.database.windows.net";
        private static string db_user = "demousr";
        private static string db_password = "Shakinstev123";
        private static string db_database = "appdb";

        private SqlConnection GetConnection(string _connection_string)
        {          
            return new SqlConnection(_connection_string);
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            // Here we now make a call to the Azure Function
            // Make sure to replace the URL with your Azure Function
            string functionurl = "https://appfunction10001.azurewebsites.net/api/GetCourses?code=iLxZHMHSBa5LxYuuFiGyRLVDVaJjN3/GesSvRCDEF8j7mVCSYh8nXw==";
            // We are using the HttpClient class to send a request to the Azure Function and to get a response
            using (HttpClient _client = new HttpClient())
            {
                HttpResponseMessage _response = await _client.GetAsync(functionurl);
                string _content=await _response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<Course>>(_content);
            }            
        }

    }
    }

    

