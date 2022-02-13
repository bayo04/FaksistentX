using FaksistentX.Services.Courses.Dtos;
using FaksistentX.Shared.ViewModels.UserSemesters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FaksistentX.Shared.Views.UserSemesters
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectCoursesPage : ContentPage
    {
        SelectCoursesViewModel viewModel;
        public SelectCoursesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new SelectCoursesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.OnAppearing();
        }

        private void SwipeItem_Invoked(object sender, DevExpress.XamarinForms.CollectionView.SwipeItemTapEventArgs e)
        {
            viewModel.SetIsSelected(e.Item as CourseDto);
        }

        private void SwipeItem_Invoked_1(object sender, DevExpress.XamarinForms.CollectionView.SwipeItemTapEventArgs e)
        {
            viewModel.RemoveIsSelected(e.Item as CourseDto);
        }
    }
}