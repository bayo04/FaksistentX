using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.UserSemesters.SemesterCourses.Dtos
{
    public class CreateSemesterCourseDto
    {
        public string UserSemesterId { get; set; }

        public string CourseId { get; set; }
    }
}
