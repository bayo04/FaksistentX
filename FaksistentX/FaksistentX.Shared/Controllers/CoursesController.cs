using FaksistentX.Services.Courses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Shared.Controllers
{
    public class CoursesController : BaseController
    {
        private CourseAppService _courseAppService;
        public CoursesController()
        {
            _courseAppService = new CourseAppService();
        }

        public async Task AddCoursePage(string Id = "")
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var semester = await _courseAppService.GetAsync(Id);
                await ChangeView(semester, true);
            }
            else
            {
                await ChangeView();
            }
        }
    }
}
