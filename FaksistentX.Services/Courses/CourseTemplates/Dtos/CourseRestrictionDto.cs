using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.Courses.CourseTemplates.Dtos
{
    public class CourseRestrictionDto
    {
        public decimal PointsForPass { get; set; }

        public decimal PointsForSignature { get; set; }

        public string CourseTemplateId { get; set; }

        public List<CourseRestrictionTestDto> Tests { get; set; }
    }
}
