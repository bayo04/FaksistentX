using FaksistentX.Services.Accounts;
using FaksistentX.Services.UserSemesters;
using FaksistentX.Shared.Stores;
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

        public string SemesterItem
        {
            get => _semesterItem;
            set => SetProperty(ref _semesterItem, value);
        }

        private UserSemesterAppService _userSemesterAppService;
        private AccountAppService _accountAppService;

        private UserSemesterStore _userSemesterStore;

        public AppShellViewModel()
        {
            _userSemesterAppService = new UserSemesterAppService();
            _accountAppService = new AccountAppService();

            _userSemesterStore = DependencyService.Get<UserSemesterStore>();

            SemesterItem = "Semesters (" + (_userSemesterStore.Data?.Name ?? "None selected") + ")";
        }

        public async void OnAppearing()
        {
            IsBusy = true;

            SemesterItem = "Semesters (" + (_userSemesterStore.Data?.Name ?? "None selected") + ")";

            IsBusy = false;
        }

        public async void Logout()
        {
            _accountAppService.Logout();
            Application.Current.MainPage = new LoginPage();
        }
    }
}
