using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.UserSemesters.SemesterCourses.Dtos
{
    public class SemesterCoursePartitionDto
    {
        public string Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool IsRecorded { get; set; }

        public bool WasSignatureRecorded { get; set; }

        public bool WasPresent { get; set; }

        public string SemesterCourseId { get; set; }

        public string CoursePartitionId { get; set; }
    }
}
