using FaksistentX.Services.Base;
using FaksistentX.Services.Courses.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.Courses
{
    public class CourseAppService : BaseAppService
    {

        public async Task<List<CourseDto>> GetAllAsync(CourseRequestDto input)
        {
            var result = await GetListAsync<CourseDto>("services/app/Course/GetAll", input);

            return result.Result.Items;
        }
    }
}
