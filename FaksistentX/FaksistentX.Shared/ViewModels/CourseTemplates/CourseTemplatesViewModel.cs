using FaksistentX.Services.Courses.CourseTemplates;
using FaksistentX.Services.Courses.CourseTemplates.Dtos;
using FaksistentX.Services.UserSemesters;
using FaksistentX.Services.UserSemesters.SemesterCourses;
using FaksistentX.Services.UserSemesters.SemesterCourses.Dtos;
using FaxistentX.Core.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FaksistentX.Shared.ViewModels.CourseTemplates
{
    public class CourseTemplatesViewModel : BaseViewModel
    {
        public ObservableCollection<CourseTemplateDto> Templates { get; set; }
        public ObservableCollection<CourseTemplateDto> MyTemplates { get; set; }

        private CourseTemplateAppService _courseTemplateAppService;
        private SemesterCourseAppService _semesterCourseAppService;
        private UserSemesterAppService _userSemesterAppService;

        public Command AddNewCommand { get; set; }
        public Command<CourseTemplateDto> EditCommand { get; set; }
        public Command<CourseTemplateDto> UseCommand { get; set; }
        public Command<CourseTemplateDto> SetCommand { get; set; }

        public CourseTemplatesViewModel()
        {
            Templates = new ObservableCollection<CourseTemplateDto>();
            MyTemplates = new ObservableCollection<CourseTemplateDto>();

            _courseTemplateAppService = new CourseTemplateAppService();
            _semesterCourseAppService = new SemesterCourseAppService();
            _userSemesterAppService = new UserSemesterAppService();

            AddNewCommand = new Command(OnAddNewCommand);
            EditCommand = new Command<CourseTemplateDto>(OnEditCommand);
            UseCommand = new Command<CourseTemplateDto>(OnUseCommand);
            SetCommand = new Command<CourseTemplateDto>(OnSetCommand);
        }

        public async void OnAppearing()
        {
            IsBusy = true;

            var templates = await _courseTemplateAppService.GetAllAsync(new CourseTemplateRequestDto { IsPublic = true });

            Templates.Clear();
            foreach (var template in templates)
            {
                Templates.Add(template);
            }

            var myTemplates = await _courseTemplateAppService.GetAllAsync(new CourseTemplateRequestDto { IsMine = true });
            var semester = await _userSemesterAppService.GetSelectedFromApiAsync();

            MyTemplates.Clear();
            foreach (var template in myTemplates)
            {
                if(semester.SemesterCourses.Any(x => x.CourseTemplateId == template.Id))
                {
                    template.IsUsed = true;
                }
                MyTemplates.Add(template);
            }

            IsBusy = false;
        }

        private void OnAddNewCommand()
        {
            InvokeControllerMethod("CourseTemplates", "CreateOrEdit");
        }

        private void OnEditCommand(CourseTemplateDto input)
        {
            InvokeControllerMethod("CourseTemplates", "CreateOrEdit", new EntityDto(input.Id));
        }

        private async void OnUseCommand(CourseTemplateDto input)
        {
            var template = await _courseTemplateAppService.CreatePrivateAsync(input.Id);

            InvokeControllerMethod("CourseTemplates", "CreateOrEdit", new EntityDto(template.Id));
        }

        private async void OnSetCommand(CourseTemplateDto input)
        {
            var semester = await _userSemesterAppService.GetSelectedAsync();
            await _semesterCourseAppService.SetTemplate(new SetTemplateDto
            {
                CourseTemplateId = input.Id,
                UserSemesterId = semester.Id,
            });

            OnAppearing();
        }
    }
}
