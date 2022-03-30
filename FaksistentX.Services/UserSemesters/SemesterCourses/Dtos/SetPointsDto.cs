using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.UserSemesters.SemesterCourses.Dtos
{
    public class SetPointsDto
    {
        public string CourseTestId { get; set; }

        public string SemesterCourseId { get; set; }

        public decimal Points { get; set; }
    }
}
