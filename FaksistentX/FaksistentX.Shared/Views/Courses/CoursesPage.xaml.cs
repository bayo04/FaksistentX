using FaksistentX.Services.Courses.Dtos;
using FaksistentX.Shared.ViewModels.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FaksistentX.Shared.Views.Courses
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoursesPage : ContentPage
    {
        CoursesViewModel viewModel;
        public CoursesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CoursesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.OnAppearing();
        }

        private void SwipeItem_Invoked(object sender, DevExpress.XamarinForms.CollectionView.SwipeItemTapEventArgs e)
        {
            viewModel.OnAddCourseCommand(e.Item as CourseDto);
        }
    }
}