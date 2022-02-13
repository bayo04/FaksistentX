using FaksistentX.Services.Base;
using FaksistentX.Services.UserSemesters.SemesterCourses.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.UserSemesters.SemesterCourses
{
    public class SemesterCourseAppService : BaseAppService
    {

        public async Task CreateCoursesForSemester(CreateMultiSemesterCoursesDto input)
        {
            await PostAsync<Guid?>("services/app/SemesterCourse/CreateCoursesForSemester", input);
        }

        public async Task<List<SemesterCourseDto>> GetAllAsync(SemesterCourseRequestDto input)
        {
            var result = await GetListAsync<SemesterCourseDto>($"services/app/SemesterCourse/GetAll", input);

            return result.Result.Items;
        }
    }
}
