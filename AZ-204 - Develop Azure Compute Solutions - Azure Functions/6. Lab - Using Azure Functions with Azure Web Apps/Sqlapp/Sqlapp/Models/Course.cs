using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sqlapp.Models
{
    public class Course
    {
        public int CourseID { get; set; }

        public string CourseName { get; set; }
        public decimal Rating { get; set; }
    }
}
