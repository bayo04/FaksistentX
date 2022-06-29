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
        private string _logoutItem;

        public string LogoutItem
        {
            get => _logoutItem;
            set => SetProperty(ref _logoutItem, value);
        }
        private bool _showCourses;

        public bool ShowCourses
        {
            get => _showCourses;
            set => SetProperty(ref _showCourses, value);
        }

        private UserSemesterAppService _userSemesterAppService;
        private AccountAppService _accountAppService;

        private UserSemesterStore _userSemesterStore;
        private UserStore _userStore;

        public AppShellViewModel()
        {
            _userSemesterAppService = new UserSemesterAppService();
            _accountAppService = new AccountAppService();

            _userSemesterStore = DependencyService.Get<UserSemesterStore>();
            _userStore = DependencyService.Get<UserStore>();

            SemesterItem = "Semestri (" + (_userSemesterStore.Data?.Name ?? "Nije odabrano") + ")";
            LogoutItem = "Odjava (" + (_userStore.Data?.UserName ?? "Nije odabrano") + ")";
            ShowCourses = _userStore.CheckIfAdmin();
        }

        public async void OnAppearing()
        {
            IsBusy = true;

            SemesterItem = "Semestri (" + (_userSemesterStore.Data?.Name ?? "Nije odabrano") + ")";
            LogoutItem = "Odjava (" + (_userStore.Data?.UserName ?? "Nije odabrano") + ")";

            IsBusy = false;
        }

        public async void Logout()
        {
            _accountAppService.Logout();
            Application.Current.MainPage = new LoginPage();
        }
    }
}
