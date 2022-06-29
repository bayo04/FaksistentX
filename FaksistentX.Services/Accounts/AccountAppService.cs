using FaksistentX.Services.Accounts.Dtos;
using FaksistentX.Services.Base;
using FaksistentX.Services.Tenants;
using FaxistentX.Core;
using FaxistentX.Core.UserSemesters;
using FaxistentX.Services.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FaksistentX.Services.Accounts
{
    public class AccountAppService : BaseAppService
    {
        private TenantAppService _tenantAppService;

        public AccountAppService()
        {
            _tenantAppService = new TenantAppService();
        }

        public async Task<UserDto> Login(string username, string password)
        {
            var tenant = await _tenantAppService.GetSelectedTenant();
            var result = await PostAsync<LoginOutput>("TokenAuth/Authenticate", new LoginInput
            {
                UserNameOrEmailAddress = username,
                Password = password,
                TenancyName = tenant.TenancyName,
                RememberClient = true
            });

            if (result.Success)
            {
                await SecureStorage.SetAsync("accessToken", result.Result.AccessToken);

                return (await GetAsync<UserDto>("services/app/User/GetCurrentUser")).Result;
            }
            return null;
        }

        public async Task<UserDto> GetCurrentUserAsync()
        {
            return (await GetAsync<UserDto>("services/app/User/GetCurrentUser")).Result;
        }

        public async Task<bool> Logout()
        {
            //await SqliteDbContext.Instance.GetConnection().Table<UserSemester>().DeleteAsync(x => true);
            return SecureStorage.Remove("accessToken");
        }

        public async Task<bool> Register(RegisterInput input)
        {
            var tenant = await _tenantAppService.GetSelectedTenant();
            if(tenant == null)
            {
                throw new Exception("Please select tenant");
            }
            else
            {
                input.TenantId = tenant.Id;
            }

            var result = await PostAsync<RegisterOutput>("services/app/Account/RegisterAnonymous", input);

            return result.Result.CanLogin;
        }

        public async Task<bool> GetCurrentLoginInformations()
        {
            var result = await GetAsync<LoginInformationsOutput>("services/app/Session/GetCurrentLoginInformations");

            try
            {
                return !string.IsNullOrEmpty(result.Result.User.UserName);
            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
