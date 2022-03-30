using FaksistentX.Services.UserSemesters.SemesterCourses.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.Courses.CourseTemplates.Dtos
{
    public class CoursePartitionDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public int TotalAttendances { get; set; }

        public int AllowedAbsences { get; set; }

        public int AllowedAbsencesWithStimulation { get; set; }

        public List<SemesterCoursePartitionDto> SemesterCoursePartitions { get; set; }

        public CoursePartitionDto()
        {
            SemesterCoursePartitions = new List<SemesterCoursePartitionDto>();
        }
    }
}
