using FaksistentX.Services.Courses.CourseTemplates.Dtos;
using FaksistentX.Services.Courses.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.UserSemesters.SemesterCourses.Dtos
{
    public class SemesterCourseDto
    {
        public string Id { get; set; }

        public string UserSemesterId { get; set; }

        public string CourseId { get; set; }

        public string CourseTemplateId { get; set; }

        public CourseDto Course { get; set; }

        public CourseTemplateDto CourseTemplate { get; set; }

        public List<SemesterCoursePartitionDto> SemesterCoursePartitions { get; set; }

        public List<SemesterCourseTestDto> SemesterCourseTests { get; set; }

        public string Title => Course.Name + " - " + (CourseTemplate != null ? CourseTemplate.Name : "Predložak nije odabran");
    }
}
