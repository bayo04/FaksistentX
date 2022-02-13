using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.Courses.CourseTemplates.Dtos
{
    public class CreateCourseTestDto
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public decimal TotalPoints { get; set; }

        public decimal PointsForPass { get; set; }

        public decimal PointsForSignature { get; set; }
    }
}
