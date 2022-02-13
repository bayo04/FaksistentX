using FaksistentX.Services.Base;
using FaksistentX.Services.Courses.CourseTemplates.Dtos;
using FaxistentX.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Services.Courses.CourseTemplates
{
    public class CourseTemplateAppService : BaseAppService
    {
        public async Task<List<CourseTemplateDto>> GetAllAsync(CourseTemplateRequestDto input)
        {
            var result = await GetListAsync<CourseTemplateDto>("services/app/CourseTemplates/GetAll", input);

            return result.Result.Items;
        }

        public async Task<CourseTemplateDto> CreateOrEditAsync(CreateCourseTemplateDto input)
        {
            if (!string.IsNullOrEmpty(input.Id))
            {
                var result = await PutAsync<CourseTemplateDto>("services/app/CourseTemplates/Update", input);

                //GetAllAsync();

                return result.Result;
            }
            else
            {
                var result = await PostAsync<CourseTemplateDto>("services/app/CourseTemplates/Create", input);

                //GetAllAsync();

                return result.Result;
            }
        }

        public async Task<CourseTemplateDto> CreatePartitionsAsync(CreateCoursePartitionsDto input)
        {
            var result = await PostAsync<CourseTemplateDto>("services/app/CourseTemplates/CreatePartitions", input);

            return result.Result;
        }

        public async Task<CourseTemplateDto> CreateTestsAsync(CreateCourseTestsDto input)
        {
            var result = await PostAsync<CourseTemplateDto>("services/app/CourseTemplates/CreateTests", input);

            return result.Result;
        }

        public async Task<CourseTemplateDto> GetAsync(string id)
        {
            var result = await GetAsync<CourseTemplateDto>("services/app/CourseTemplates/Get", new EntityDto(id));

            return result.Result;
        }
    }
}
