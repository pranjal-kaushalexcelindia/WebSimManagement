using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSim.DTO
{
    public class CourseDetail
    {
        public Guid courseid { get; set; }
        public string coursename { get; set; }
        public string coursedescription { get; set; }
    }
}
