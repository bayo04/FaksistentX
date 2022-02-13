using FaksistentX.Services.UserSemesters;
using FaksistentX.Services.UserSemesters.Dtos;
using FaksistentX.Shared.Views.UserSemesters;
using FaxistentX.Core.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FaksistentX.Shared.ViewModels.UserSemesters
{
    public class UserSemestersViewModel : BaseViewModel
    {
        private readonly UserSemesterAppService _userSemesterAppService;
        public List<UserSemesterDto> UserSemesters { get; set; }

        public Command LoadUserSemestersCommand { get; set; }
        public Command AddSemesterCommand { get; set; }

        private UserSemestersPage _page;

        public UserSemestersViewModel(UserSemestersPage page)
        {
            _userSemesterAppService = new UserSemesterAppService();
            LoadUserSemestersCommand = new Command(async () => await ExecuteLoadUserSemestersCommand());
            AddSemesterCommand = new Command(OnSemesterCommand);

            _page = page;

            UserSemesters = new List<UserSemesterDto>();
        }

        public async Task ExecuteLoadUserSemestersCommand()
        {
            IsBusy = true;
            var semsesters = await _userSemesterAppService.GetAllAsync();

            foreach (var semsester in semsesters)
            {
                UserSemesters.Add(semsester);
            }
            IsBusy = false;
        }

        public async void OnAppearing()
        {
            IsBusy = true;
            var semesters = await _userSemesterAppService.GetAllAsync();

            UserSemesters.Clear();
            foreach (var semsester in semesters)
            {
                UserSemesters.Add(semsester);
            }
            IsBusy = false;
        }

        private async void OnSemesterCommand(object sender)
        {
            InvokeControllerMethod("UserSemesters", "AddUserSemester");
        }

        public void OnUpdate(string id)
        {
            InvokeControllerMethod("UserSemesters", "AddUserSemester", new EntityDto(id));
        }
    }
}
