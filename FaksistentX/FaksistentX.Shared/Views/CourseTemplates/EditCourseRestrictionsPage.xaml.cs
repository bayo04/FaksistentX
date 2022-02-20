using FaksistentX.Shared.ViewModels.CourseTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FaksistentX.Shared.Views.CourseTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditCourseRestrictionsPage : ContentPage
    {
        EditRestrictionsViewModel viewModel;
        public EditCourseRestrictionsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new EditRestrictionsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}