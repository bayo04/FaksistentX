using FaksistentX.Services.Base;
using FaksistentX.Services.UserSemesters.SemesterCourses.Dtos;
using FaxistentX.Core.Base;
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

        public async Task<SemesterCourseDto> GetAsync(string id)
        {
            var result = await GetAsync<SemesterCourseDto>("services/app/SemesterCourse/Get", new EntityDto(id));

            return result.Result;
        }

        public async Task SetTemplate(SetTemplateDto input)
        {
            await PostAsync<Guid?>("services/app/SemesterCourse/SetTemplate", input);
        }

        public async Task SetPoints(SetPointsDto input)
        {
            await PostAsync<Guid?>("services/app/SemesterCourse/SetPoints", input);
        }
    }
}
