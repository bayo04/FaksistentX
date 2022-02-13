using FaksistentX.Services.UserSemesters;
using System;
using System.Collections.Generic;
using System.Text;

namespace FaksistentX.Shared.ViewModels
{
    public class AppShellViewModel : BaseViewModel
    {
        private string _semesterItem;

        private UserSemesterAppService _userSemesterAppService;

        public AppShellViewModel()
        {
            _userSemesterAppService = new UserSemesterAppService();
        }

        public string SemesterItem
        {
            get => _semesterItem;
            set => SetProperty(ref _semesterItem, value);
        }

        public async void OnAppearing()
        {
            SemesterItem = (await _userSemesterAppService.GetSelectedAsync()).Name;
        }
    }
}
