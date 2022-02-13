using FaksistentX.Services.Courses.CourseTemplates;
using FaksistentX.Services.Courses.CourseTemplates.Dtos;
using FaxistentX.Core.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace FaksistentX.Shared.ViewModels.CourseTemplates
{
    public class CourseTemplatesViewModel : BaseViewModel
    {
        public ObservableCollection<CourseTemplateDto> Templates { get; set; }

        private CourseTemplateAppService _courseTemplateAppService;

        public Command AddNewCommand { get; set; }
        public Command<CourseTemplateDto> EditCommand { get; set; }

        public CourseTemplatesViewModel()
        {
            Templates = new ObservableCollection<CourseTemplateDto>();

            _courseTemplateAppService = new CourseTemplateAppService();

            AddNewCommand = new Command(OnAddNewCommand);
            EditCommand = new Command<CourseTemplateDto>(OnEditCommand);
        }

        public async void OnAppearing()
        {
            var templates = await _courseTemplateAppService.GetAllAsync(new CourseTemplateRequestDto { IsPublic = true });

            Templates.Clear();
            foreach (var template in templates)
            {
                Templates.Add(template);
            }
        }

        private void OnAddNewCommand()
        {
            InvokeControllerMethod("CourseTemplates", "CreateOrEdit");
        }

        private void OnEditCommand(CourseTemplateDto input)
        {
            InvokeControllerMethod("CourseTemplates", "CreateOrEdit", new EntityDto(input.Id));
        }
    }
}
