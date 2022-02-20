using FaksistentX.Services.Courses.CourseTemplates;
using FaxistentX.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Shared.Controllers
{
    public class CourseTemplatesController : BaseController
    {
        private CourseTemplateAppService _courseTemplateAppService;
        public CourseTemplatesController()
        {
            _courseTemplateAppService = new CourseTemplateAppService();
        }

        public async Task CreateOrEditPage(string Id = "")
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var template = await _courseTemplateAppService.GetAsync(Id);
                await ChangeView(template, true);
            }
            else
            {
                await ChangeView();
            }
        }

        public async Task EditPartitionsPage(string Id)
        {
            await ChangeView(new EntityDto(Id));
        }

        public async Task EditTestsPage(string Id)
        {
            await ChangeView(new EntityDto(Id));
        }

        public async Task EditCourseRestrictionsPage(string Id)
        {
            await ChangeView(new EntityDto(Id));
        }
    }
}
