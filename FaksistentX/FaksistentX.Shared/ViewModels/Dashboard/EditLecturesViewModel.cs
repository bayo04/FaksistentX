using FaksistentX.Services.Courses.CourseTemplates;
using FaksistentX.Services.Courses.CourseTemplates.Dtos;
using FaksistentX.Services.UserSemesters.SemesterCourses;
using FaksistentX.Services.UserSemesters.SemesterCourses.Dtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FaksistentX.Shared.ViewModels.Dashboard
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class EditLecturesViewModel : BaseViewModel
    {
        public string Id { get; set; }

        public SemesterCourseDto Course { get; set; }

        public ObservableCollection<CoursePartitionDto> Partitions { get; set; }

        private CourseTemplateAppService _courseTemplateAppService;
        private SemesterCourseAppService _semesterCourseAppService;

        public EditLecturesViewModel()
        {

            _courseTemplateAppService = new CourseTemplateAppService();
            _semesterCourseAppService = new SemesterCourseAppService();

            Partitions = new ObservableCollection<CoursePartitionDto>();
        }

        public async void OnAppearing()
        {
            IsBusy = true;

            Course = await _semesterCourseAppService.GetAsync(Id);

            Partitions.Clear();
            foreach(var partition in Course.CourseTemplate.CoursePartitions)
            {
                partition.SemesterCoursePartitions.Clear();
                partition.SemesterCoursePartitions
                    .AddRange(Course.SemesterCoursePartitions.Where(x => x.CoursePartitionId == partition.Id));

                Partitions.Add(partition);
            }

            IsBusy = false;
        }
    }
}
