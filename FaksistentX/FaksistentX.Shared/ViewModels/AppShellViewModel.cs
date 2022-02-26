using FaksistentX.Services.Accounts;
using FaksistentX.Services.UserSemesters;
using FaksistentX.Shared.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FaksistentX.Shared.ViewModels
{
    public class AppShellViewModel : BaseViewModel
    {
        private string _semesterItem;

        private UserSemesterAppService _userSemesterAppService;
        private AccountAppService _accountAppService;

        public AppShellViewModel()
        {
            _userSemesterAppService = new UserSemesterAppService();
            _accountAppService = new AccountAppService();
        }

        public string SemesterItem
        {
            get => _semesterItem;
            set => SetProperty(ref _semesterItem, value);
        }

        public async void OnAppearing()
        {
            //SemesterItem = (await _userSemesterAppService.GetSelectedAsync()).Name;
        }

        public async void Logout()
        {
            _accountAppService.Logout();
            Application.Current.MainPage = new LoginPage();
        }
    }
}
