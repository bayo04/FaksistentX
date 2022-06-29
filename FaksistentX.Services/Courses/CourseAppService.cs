using FaksistentX.Services.Base;
using FaksistentX.Services.Courses.Dtos;
using FaxistentX.Core.Base;
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

        public async Task<CourseDto> GetAsync(string id)
        {
            var result = await GetAsync<CourseDto>("services/app/Course/Get", new EntityDto(id));

            return result.Result;
        }

        public async Task<CourseDto> CreateOrEditAsync(CourseDto input)
        {
            if (!string.IsNullOrEmpty(input.Id))
            {
                var result = await PutAsync<CourseDto>("services/app/Course/Update", input);

                return result.Result;
            }
            else
            {
                var result = await PostAsync<CourseDto>("services/app/Course/Create", input);

                return result.Result;
            }
        }
    }
}
