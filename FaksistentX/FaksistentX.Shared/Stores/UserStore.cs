using FaksistentX.Services.Accounts;
using FaksistentX.Services.Accounts.Dtos;
using FaksistentX.Shared.Actions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FaksistentX.Shared.Stores
{
    public class UserStore : BaseStore<UserDto>
    {
        private AccountAppService _accountAppService;

        public UserStore()
        {
            _accountAppService = new AccountAppService();
        }

        public override async Task Invoke<TData>(string eventType, TData data)
        {
            switch (eventType)
            {
                case UserActionTypes.GET_USER:
                    await GetUser();
                    break;
                case UserActionTypes.SET_USER:
                    await SetUser(data as UserDto);
                    break;
            }
        }

        private async Task SetUser(UserDto user)
        {
            Data = user;
        }

        private async Task GetUser()
        {
            Data = await _accountAppService.GetCurrentUserAsync();
        }

        public bool CheckIfAdmin()
        {
            return Data?.RoleNames.Contains("ADMIN") ?? false;
        }
    }
}
