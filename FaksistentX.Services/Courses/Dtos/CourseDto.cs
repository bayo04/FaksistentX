using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.Courses.Dtos
{
    public class CourseDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public int SemesterNo { get; set; }

        public bool IsSelected { get; set; }

        public string Color => IsSelected ? "GreenYellow" : "White";
    }
}
