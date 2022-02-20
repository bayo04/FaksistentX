using FaksistentX.Services.Courses.CourseTemplates;
using FaksistentX.Services.Courses.CourseTemplates.Dtos;
using FaxistentX.Core.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FaksistentX.Shared.ViewModels.CourseTemplates
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class EditRestrictionsViewModel : BaseViewModel
    {
        public string Id { get; set; }
        public ObservableCollection<CreateCourseRestrictionDto> Restrictions { get; set; }
        public List<CourseTestDto> CourseTests { get; set; }

        public Command AddNewCommand { get; set; }
        public Command<CreateCourseRestrictionDto> AddNewTestCommand { get; set; }
        public Command SaveAndContinueCommand { get; set; }
        public Command<CreateCourseRestrictionDto> RemoveCommand { get; set; }

        public CourseTemplateAppService _courseTemplateAppService { get; set; }
        public EditRestrictionsViewModel()
        {
            Restrictions = new ObservableCollection<CreateCourseRestrictionDto>();
            CourseTests = new List<CourseTestDto>();

            AddNewCommand = new Command(OnAddNewCommand);
            AddNewTestCommand = new Command<CreateCourseRestrictionDto>(OnAddNewTestCommand);
            SaveAndContinueCommand = new Command(OnSaveAndContinueCommand);
            RemoveCommand = new Command<CreateCourseRestrictionDto>(OnRemoveCommand);

            _courseTemplateAppService = new CourseTemplateAppService();
        }

        public async void OnAppearing()
        {
            IsBusy = true;

            var template = await _courseTemplateAppService.GetAsync(Id);
            CourseTests.Clear();
            CourseTests.AddRange(template.CourseTests);
            Restrictions.Clear();
            foreach (var restriction in template.CourseRestrictions)
            {
                Restrictions.Add(new CreateCourseRestrictionDto
                {
                    PointsForPass = restriction.PointsForPass,
                    PointsForSignature = restriction.PointsForSignature,
                    CourseTestIdsHelper = new ObservableCollection<EntityDto>(restriction.Tests.Select(x => new EntityDto(x.CourseTestId)))
                });
            }

            IsBusy = false;
        }

        private void OnAddNewCommand()
        {
            IsBusy = true;
            Restrictions.Add(new CreateCourseRestrictionDto());
            IsBusy = false;
        }

        private void OnAddNewTestCommand(CreateCourseRestrictionDto input)
        {
            IsBusy = true;
            input.CourseTestIdsHelper.Add(new EntityDto(""));
            IsBusy = false;
        }

        private void OnRemoveCommand(CreateCourseRestrictionDto input)
        {
            Restrictions.Remove(input);
        }
        private async void OnSaveAndContinueCommand()
        {
            await _courseTemplateAppService.CreateRestrictionsAsync(new CreateCourseRestrictionsDto
            {
                Restrictions = Restrictions.ToList(),
                CourseTemplateId = Id
            });
        }
    }
}
