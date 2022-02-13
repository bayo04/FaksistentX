using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.Courses.CourseTemplates.Dtos
{
    public class CreateCourseTemplateDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string CourseId { get; set; }

        public bool IsPublic { get; set; }
    }
}
