using FaksistentX.Services.Courses;
using FaksistentX.Services.Courses.CourseTemplates;
using FaksistentX.Services.Courses.CourseTemplates.Dtos;
using FaksistentX.Services.Courses.Dtos;
using FaxistentX.Core.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FaksistentX.Shared.ViewModels.CourseTemplates
{
    [QueryProperty(nameof(JsonValue), nameof(JsonValue))]
    public class CreateOrEditViewModel : BaseViewModel
    {
        private string _name;
        private string _courseId;
        private bool _isPublic;

        public string Id { get; set; }
        public string JsonValue { get; set; }

        public ObservableCollection<CourseDto> Courses { get; set; }

        private CourseAppService _courseAppService;
        private CourseTemplateAppService _courseTemplateAppService;
        public Command SaveCommand { get; }
        public Command SaveAndContinueCommand { get; }

        public CreateOrEditViewModel()
        {
            Courses = new ObservableCollection<CourseDto>();
            SaveCommand = new Command(OnSaveCommand);
            SaveAndContinueCommand = new Command(OnSaveAndContinueCommand);

            _courseAppService = new CourseAppService();
            _courseTemplateAppService = new CourseTemplateAppService();
        }

        public string Name 
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string CourseId 
        {
            get => _courseId;
            set => SetProperty(ref _courseId, value);
        }

        public bool IsPublic 
        {
            get => _isPublic;
            set => SetProperty(ref _isPublic, value);
        }

        public async void OnAppearing()
        {
            var courses = await _courseAppService.GetAllAsync(new CourseRequestDto());

            Courses.Clear();
            foreach (var course in courses)
            {
                Courses.Add(course);
            }
            if (!string.IsNullOrEmpty(JsonValue))
            {
                var semester = JsonConvert.DeserializeObject<CreateCourseTemplateDto>(JsonValue);

                Id = semester.Id;
                Name = semester.Name;
                CourseId = semester.CourseId;
                IsPublic = semester.IsPublic;
            }
        }

        private async Task<CourseTemplateDto> Save()
        {
            return await _courseTemplateAppService.CreateOrEditAsync(new CreateCourseTemplateDto
            {
                Id = Id,
                Name = _name,
                CourseId = _courseId,
                IsPublic = _isPublic
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

            InvokeControllerMethod("CourseTemplates", "EditPartitions", new EntityDto(added.Id));
        }
    }
}
