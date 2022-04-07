using FaksistentX.Services.Courses.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.Courses.CourseTemplates.Dtos
{
    public class CourseTemplateDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string CourseId { get; set; }

        public bool IsPublic { get; set; }

        public CourseDto Course { get; set; }

        public List<CoursePartitionDto> CoursePartitions { get; set; }

        public List<CourseTestDto> CourseTests { get; set; }

        public List<CourseRestrictionDto> CourseRestrictions { get; set; }

        public bool IsUsed { get; set; }

        public string BackgroundColor => IsUsed ? "GreenYellow" : "white";
    }
}
