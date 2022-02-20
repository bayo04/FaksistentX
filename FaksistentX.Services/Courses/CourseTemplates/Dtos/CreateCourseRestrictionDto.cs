using FaxistentX.Core.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.Courses.CourseTemplates.Dtos
{
    public class CreateCourseRestrictionDto
    {
        public decimal PointsForPass { get; set; }

        public decimal PointsForSignature { get; set; }

        public string CourseTemplateId { get; set; }

        public List<string> CourseTestIds { get; set; }

        public ObservableCollection<EntityDto> CourseTestIdsHelper { get; set; }

        public string CollectionName => "TestsCollection" + Guid.NewGuid();

        public CreateCourseRestrictionDto()
        {
            CourseTestIds = new List<string>();
            CourseTestIdsHelper = new ObservableCollection<EntityDto>();
        }
    }
}
