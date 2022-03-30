using FaksistentX.Services.Courses.CourseTemplates.Dtos;
using FaksistentX.Shared.ViewModels.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FaksistentX.Shared.Views.Dashboard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseDetailsPage : ContentPage
    {
        CourseDetailsViewModel viewModel;
        public CourseDetailsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CourseDetailsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var model = (e as TappedEventArgs).Parameter as CourseTestDto;
            string result = await DisplayPromptAsync(model.Name, "Points");
            decimal points = 0;
            decimal.TryParse(result, out points);

            viewModel.SetPoints(model.Id, points);
        }
    }
}