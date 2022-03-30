using FaksistentX.Services.Courses.CourseTemplates.Dtos;
using FaksistentX.Services.UserSemesters.SemesterCourses;
using FaksistentX.Services.UserSemesters.SemesterCourses.Dtos;
using FaxistentX.Core.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FaksistentX.Shared.ViewModels.Dashboard
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class CourseDetailsViewModel : BaseViewModel
    {
        public string Id { get; set; }

        public SemesterCourseDto SemesterCourse { get; set; }

        public ObservableCollection<CourseTestDto> Tests { get; set; }

        private SemesterCourseAppService _semesterCourseAppService;


        public CourseDetailsViewModel()
        {
            _semesterCourseAppService = new SemesterCourseAppService();

            Tests = new ObservableCollection<CourseTestDto>();
        }

        public async void OnAppearing()
        {
            IsBusy = true;
            SemesterCourse = await _semesterCourseAppService.GetAsync(Id);

            Tests.Clear();
            foreach (var test in SemesterCourse.CourseTemplate.CourseTests)
            {
                if(SemesterCourse.SemesterCourseTests.Any(x => x.CourseTestId == test.Id))
                {
                    test.MyPoints = SemesterCourse.SemesterCourseTests.FirstOrDefault(x => x.CourseTestId == test.Id).Points;
                }
                Tests.Add(test);
            }
            IsBusy = false;
        }

        public async void SetPoints(string testId, decimal points)
        {
            await _semesterCourseAppService.SetPoints(new SetPointsDto { CourseTestId = testId, Points = points, SemesterCourseId = Id });
        }
    }
}
