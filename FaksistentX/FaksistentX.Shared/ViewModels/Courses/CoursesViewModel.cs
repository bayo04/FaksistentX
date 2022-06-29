using FaksistentX.Services.Courses;
using FaksistentX.Services.Courses.Dtos;
using FaxistentX.Core.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FaksistentX.Shared.ViewModels.Courses
{
    public class CoursesViewModel : BaseViewModel
    {
        private readonly CourseAppService _courseAppService;
        public ObservableCollection<CourseDto> Courses { get; set; }

        public Command<CourseDto> AddCourseCommand { get; set; }

        public CoursesViewModel()
        {
            _courseAppService = new CourseAppService();
            AddCourseCommand = new Command<CourseDto>(OnAddCourseCommand);

            Courses = new ObservableCollection<CourseDto>();
        }

        public async void OnAppearing()
        {
            IsBusy = true;
            var courses = await _courseAppService.GetAllAsync(new CourseRequestDto());

            Courses.Clear();
            foreach (var course in courses)
            {
                Courses.Add(course);
            }
            IsBusy = false;
        }

        public async void OnAddCourseCommand(CourseDto course = null)
        {
            if(course != null)
            {
                InvokeControllerMethod("Courses", "AddCourse", new EntityDto(course.Id));

            }
            else
            {
                InvokeControllerMethod("Courses", "AddCourse");
            }
        }
    }
}
