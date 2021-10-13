using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Course
    {
        public string CourseID { get; set; }

        public string CourseName { get; set; }
        public float Rating { get; set; }
    }
}
