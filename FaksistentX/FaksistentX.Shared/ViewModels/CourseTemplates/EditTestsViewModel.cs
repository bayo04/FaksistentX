using FaksistentX.Services.Courses.CourseTemplates;
using FaksistentX.Services.Courses.CourseTemplates.Dtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FaksistentX.Shared.ViewModels.CourseTemplates
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class EditTestsViewModel : BaseViewModel
    {
        public string Id { get; set; }

        public ObservableCollection<CreateCourseTestDto> Tests { get; set; }

        public Command AddNewCommand { get; set; }
        public Command SaveAndContinueCommand { get; set; }
        public Command<CreateCourseTestDto> RemoveCommand { get; set; }

        public CourseTemplateAppService _courseTemplateAppService { get; set; }
        public EditTestsViewModel()
        {
            Tests = new ObservableCollection<CreateCourseTestDto>();

            AddNewCommand = new Command(OnAddNewCommand);
            SaveAndContinueCommand = new Command(OnSaveAndContinueCommand);
            RemoveCommand = new Command<CreateCourseTestDto>(OnRemoveCommand);

            _courseTemplateAppService = new CourseTemplateAppService();
        }

        public async void OnAppearing()
        {
            var template = await _courseTemplateAppService.GetAsync(Id);
            foreach (var partiton in template.CourseTests)
            {
                Tests.Add(new CreateCourseTestDto
                {
                    TotalPoints = partiton.TotalPoints,
                    PointsForPass = partiton.PointsForPass,
                    Code = partiton.Code,
                    Name = partiton.Name,
                    PointsForSignature = partiton.PointsForSignature,
                });
            }
        }

        private void OnAddNewCommand()
        {
            Tests.Add(new CreateCourseTestDto());
        }

        private void OnRemoveCommand(CreateCourseTestDto input)
        {
            Tests.Remove(input);
        }
        private async void OnSaveAndContinueCommand()
        {
            await _courseTemplateAppService.CreateTestsAsync(new CreateCourseTestsDto
            {
                Tests = Tests.ToList(),
                CourseTemplateId = Id
            });
        }
    }
}
