using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.Courses.CourseTemplates.Dtos
{
    public class CreateCourseRestrictionsDto
    {
        public string CourseTemplateId { get; set; }

        public List<CreateCourseRestrictionDto> Restrictions { get; set; }
    }
}
