using FaksistentX.Services.Courses;
using FaksistentX.Services.Courses.Dtos;
using FaksistentX.Services.UserSemesters.SemesterCourses;
using FaksistentX.Services.UserSemesters.SemesterCourses.Dtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FaksistentX.Shared.ViewModels.UserSemesters
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class SelectCoursesViewModel : BaseViewModel
    {
        public string Id { get; set; }

        private CourseAppService _courseAppService;
        private SemesterCourseAppService _semesterCourseAppService;

        public ObservableCollection<CourseDto> Courses { get; set; }

        public Command SaveCommand { get; set; }

        public SelectCoursesViewModel()
        {
            _courseAppService = new CourseAppService();
            _semesterCourseAppService = new SemesterCourseAppService();

            Courses = new ObservableCollection<CourseDto>();

            SaveCommand = new Command(OnSaveCommand);
        }

        public async void OnAppearing()
        {
            IsBusy = true;

            Courses.Clear();
            var courses = await _courseAppService.GetAllAsync(new CourseRequestDto());
            var semesterCourses = await _semesterCourseAppService.GetAllAsync(new SemesterCourseRequestDto { UserSemesterId = Id});

            foreach(var course in courses)
            {
                course.IsSelected = semesterCourses.Any(x => x.CourseId == course.Id);
            }

            courses = courses.OrderBy(x => !x.IsSelected).ThenBy(x => x.Name).ToList();

            foreach (var course in courses)
            {
                Courses.Add(course);
            }

            IsBusy = false;
        }

        public void SetIsSelected(CourseDto course)
        {
            IsBusy = true;

            var courses = Courses.ToList();
            courses.Remove(course);

            course.IsSelected = true;

            courses.Add(course);

            courses = courses.OrderBy(x => !x.IsSelected).ThenBy(x => x.Name).ToList();

            Courses.Clear();
            foreach (var c in courses)
            {
                Courses.Add(c);
            }

            IsBusy = false;
        }

        public void RemoveIsSelected(CourseDto course)
        {
            IsBusy = true;

            var courses = Courses.ToList();
            courses.Remove(course);

            course.IsSelected = false;

            courses.Add(course);

            courses = courses.OrderBy(x => !x.IsSelected).ThenBy(x => x.Name).ToList();

            Courses.Clear();
            foreach (var c in courses)
            {
                Courses.Add(c);
            }

            IsBusy = false;
        }

        private async void OnSaveCommand(object sender)
        {
            await _semesterCourseAppService.CreateCoursesForSemester(new CreateMultiSemesterCoursesDto { 
                Courses = Courses.Where(x => x.IsSelected).Select(x => new CreateSemesterCourseDto { CourseId = x.Id, UserSemesterId = Id}).ToList(),
                UserSemesterId = Id
            });
        }
    }
}
