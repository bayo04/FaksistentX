using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.Courses.CourseTemplates.Dtos
{
    public class CreateCoursePartitionsDto
    {
        public string CourseTemplateId { get; set; }

        public List<CreateCoursePartitionDto> Partitions { get; set; }
    }
}
