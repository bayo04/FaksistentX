using FaksistentX.Services.UserSemesters;
using FaxistentX.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Shared.Controllers
{
    public class UserSemestersController : BaseController
    {
        private UserSemesterAppService _userSemesterAppService;
        public UserSemestersController()
        {
            _userSemesterAppService = new UserSemesterAppService();
        }

        public async Task AddUserSemesterPage(string Id = "")
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var semester = await _userSemesterAppService.GetAsync(Id);
                await ChangeView(semester, true);
            }
            else
            {
                await ChangeView();
            }
        }

        public async Task<bool> DeleteUserSemester(string id)
        {
            return await _userSemesterAppService.DeleteAsync(id);
        }

        public async Task<bool> SetIsSelected(string id)
        {
            return await _userSemesterAppService.SetIsSelectedAsync(id);
        }

        public async Task SelectCoursesPage(string Id)
        {
            await ChangeView(new EntityDto(Id));
        }
    }
}
