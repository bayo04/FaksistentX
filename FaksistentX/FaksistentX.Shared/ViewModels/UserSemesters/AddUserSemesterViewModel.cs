using FaksistentX.Services.Tenants;
using FaksistentX.Services.UserSemesters;
using FaksistentX.Services.UserSemesters.Dtos;
using FaxistentX.Core.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FaksistentX.Shared.ViewModels.UserSemesters
{
    [QueryProperty(nameof(JsonValue), nameof(JsonValue))]
    public class AddUserSemesterViewModel : BaseViewModel
    {
        public string JsonValue { get; set; }
        public string Id { get; set; }
        private string _semesterName;
        private int _semesterNo;
        private int _maxSemesterNoValue;
        private DateTime _startDate = DateTime.Now;
        private DateTime _endDate = DateTime.Now.AddMonths(3);

        public Command SaveCommand { get; }
        public Command SaveAndContinueCommand { get; }

        private UserSemesterAppService _userSemesterAppService { get; set; }
        private TenantAppService _tenantAppService { get; set; }

        public AddUserSemesterViewModel()
        {
            SaveCommand = new Command(OnSaveCommand);
            SaveAndContinueCommand = new Command(OnSaveAndContinueCommand);

            _userSemesterAppService = new UserSemesterAppService();
            _tenantAppService = new TenantAppService();
        }

        public string SemesterName
        {
            get => _semesterName;
            set => SetProperty(ref _semesterName, value);
        }

        public int SemesterNo
        {
            get => _semesterNo;
            set => SetProperty(ref _semesterNo, value);
        }

        public int MaxSemesterNoValue
        {
            get => _maxSemesterNoValue;
            set => SetProperty(ref _maxSemesterNoValue, value);
        }

        public DateTime StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        public DateTime EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }

        public async void OnAppearing()
        {
            var tenant = await _tenantAppService.GetSelectedTenant();
            MaxSemesterNoValue = tenant.NoOfSemesters;

            if (!string.IsNullOrEmpty(JsonValue))
            {
                var semester = JsonConvert.DeserializeObject<UserSemesterDto>(JsonValue);

                Id = semester.Id;
                SemesterName = semester.Name;
                SemesterNo = semester.SemesterNo;
                StartDate = semester.StartDate;
                EndDate = semester.EndDate;
            }
        }

        private async Task<UserSemesterDto> Save()
        {
            return await _userSemesterAppService.CreateOrEditAsync(new CreateUserSemesterDto
            {
                Id = Id,
                Name = SemesterName,
                SemesterNo = SemesterNo,
                StartDate = StartDate,
                EndDate = EndDate
            });
        }

        private async void OnSaveCommand(object obj)
        {
            await Save();

            GoBack();
        }
        
        private async void OnSaveAndContinueCommand(object obj)
        {
            var added = await Save();

            InvokeControllerMethod("UserSemesters", "SelectCourses", new EntityDto(added.Id));
        }
    }
}
