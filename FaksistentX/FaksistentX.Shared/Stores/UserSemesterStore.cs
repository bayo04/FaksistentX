using FaksistentX.Services.UserSemesters;
using FaksistentX.Services.UserSemesters.Dtos;
using FaksistentX.Shared.Actions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Shared.Stores
{
    public class UserSemesterStore : BaseStore<UserSemesterDto>
    {
        private UserSemesterAppService _userSemesterAppService;

        public UserSemesterStore()
        {
            _userSemesterAppService = new UserSemesterAppService();
        }

        public override async Task Invoke<TData>(string eventType, TData data)
        {
            switch (eventType)
            {
                case UserSemesterActionTypes.GET_SEMESTER:
                    await GetSemester();
                    break;
            }
        }

        private async Task GetSemester()
        {
            Data = await _userSemesterAppService.GetSelectedFromApiAsync();
        }
    }
}
