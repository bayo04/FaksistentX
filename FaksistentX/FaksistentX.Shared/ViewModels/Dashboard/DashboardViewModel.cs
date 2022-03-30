using FaksistentX.Services.Courses;
using FaksistentX.Services.Courses.Dtos;
using FaksistentX.Services.UserSemesters;
using FaksistentX.Services.UserSemesters.SemesterCourses;
using FaksistentX.Services.UserSemesters.SemesterCourses.Dtos;
using FaxistentX.Core.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace FaksistentX.Shared.ViewModels.Dashboard
{
    public class DashboardViewModel : BaseViewModel
    {
        public ObservableCollection<SemesterCourseDto> Courses { get; set; }

        private SemesterCourseAppService _semesterCourseAppService;
        private UserSemesterAppService _userSemesterAppService;

        public Command<SemesterCourseDto> CourseDetailsCommand { get; set; }

        public DashboardViewModel()
        {
            Courses = new ObservableCollection<SemesterCourseDto>();

            _userSemesterAppService = new UserSemesterAppService();
            _semesterCourseAppService = new SemesterCourseAppService();

            CourseDetailsCommand = new Command<SemesterCourseDto>(OnCourseDetailsCommand);
        }

        public async void OnAppearing()
        {
            IsBusy = true;

            await _userSemesterAppService.GetAllAsync();

            var semester = await _userSemesterAppService.GetSelectedAsync();

            Courses.Clear();
            if (semester != null)
            {
                var courses = await _semesterCourseAppService.GetAllAsync(new SemesterCourseRequestDto { UserSemesterId = semester.Id });

                foreach (var course in courses)
                {
                    Courses.Add(course);
                }
            }

            IsBusy = false;
        }

        private void OnCourseDetailsCommand(SemesterCourseDto course)
        {
            InvokeControllerMethod("Dashboard", "CourseDetails", new EntityDto(course.Id));
        }
    }
}
