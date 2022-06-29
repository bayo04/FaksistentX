using FaksistentX.Services.Courses;
using FaksistentX.Services.Courses.Dtos;
using FaksistentX.Services.Tenants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FaksistentX.Shared.ViewModels.Courses
{
    [QueryProperty(nameof(JsonValue), nameof(JsonValue))]
    public class AddCourseViewModel : BaseViewModel
    {
        public string JsonValue { get; set; }

        public string Id { get; set; }

        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _shortName;

        public string ShortName
        {
            get => _shortName;
            set => SetProperty(ref _shortName, value);
        }

        private int _semesterNo;

        public int SemesterNo
        {
            get => _semesterNo;
            set => SetProperty(ref _semesterNo, value);
        }

        private int _maxSemesterNoValue;
        public int MaxSemesterNoValue
        {
            get => _maxSemesterNoValue;
            set => SetProperty(ref _maxSemesterNoValue, value);
        }

        public Command SaveCommand { get; }

        private TenantAppService _tenantAppService { get; set; }
        private CourseAppService _courseAppService { get; set; }

        public AddCourseViewModel()
        {
            SaveCommand = new Command(OnSaveCommand);

            _courseAppService = new CourseAppService();
            _tenantAppService = new TenantAppService();
        }
        public async void OnAppearing()
        {
            var tenant = await _tenantAppService.GetSelectedTenant();
            MaxSemesterNoValue = tenant.NoOfSemesters;

            if (!string.IsNullOrEmpty(JsonValue))
            {
                var semester = JsonConvert.DeserializeObject<CourseDto>(JsonValue);

                Id = semester.Id;
                Name = semester.Name;
                ShortName = semester.ShortName;
                SemesterNo = semester.SemesterNo;
            }
        }

        private async void OnSaveCommand(object obj)
        {
            await _courseAppService.CreateOrEditAsync(new CourseDto
            {
                Id = Id,
                Name = Name,
                ShortName = ShortName,
                SemesterNo = SemesterNo,
            });

            GoBack();
        }
    }
}
