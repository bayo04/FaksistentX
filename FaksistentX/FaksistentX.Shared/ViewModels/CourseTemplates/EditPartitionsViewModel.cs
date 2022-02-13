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
    public class EditPartitionsViewModel : BaseViewModel
    {
        public string Id { get; set; }

        public ObservableCollection<CreateCoursePartitionDto> Partitions { get; set; }

        public Command AddNewCommand { get; set; }
        public Command SaveAndContinueCommand { get; set; }
        public Command<CreateCoursePartitionDto> RemoveCommand { get; set; }

        public CourseTemplateAppService _courseTemplateAppService { get; set; }
        public EditPartitionsViewModel()
        {
            Partitions = new ObservableCollection<CreateCoursePartitionDto>();

            AddNewCommand = new Command(OnAddNewCommand);
            SaveAndContinueCommand = new Command(OnSaveAndContinueCommand);
            RemoveCommand = new Command<CreateCoursePartitionDto>(OnRemoveCommand);

            _courseTemplateAppService = new CourseTemplateAppService();
        }

        public async void OnAppearing()
        {
            var template = await _courseTemplateAppService.GetAsync(Id);
            foreach (var partiton in template.CoursePartitions)
            {
                Partitions.Add(new CreateCoursePartitionDto
                {
                    AllowedAbsences = partiton.AllowedAbsences,
                    AllowedAbsencesWithStimulation = partiton.AllowedAbsencesWithStimulation,
                    Code = partiton.Code,
                    Name = partiton.Name,
                    TotalAttendances = partiton.TotalAttendances,
                });
            }
        }

        private void OnAddNewCommand()
        {
            Partitions.Add(new CreateCoursePartitionDto());
        }

        private void OnRemoveCommand(CreateCoursePartitionDto input)
        {
            Partitions.Remove(input);
        }
        private async void OnSaveAndContinueCommand()
        {
            await _courseTemplateAppService.CreatePartitionsAsync(new CreateCoursePartitionsDto
            {
                Partitions = Partitions.ToList(),
                CourseTemplateId = Id
            });

            InvokeControllerMethod("CourseTemplates", "EditTests", new EntityDto(Id));
        }
    }
}
