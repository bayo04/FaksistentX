using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.UserSemesters.SemesterCourses.Dtos
{
    public class SemesterCourseTestDto
    {
        public string Id { get; set; }

        public decimal Points { get; set; }

        public string SemesterCourseId { get; set; }

        public string CourseTestId { get; set; }
    }
}
