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
    public partial class CourseTemplatesPage : ContentPage
    {
        private CourseTemplatesViewModel viewModel;
        public CourseTemplatesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CourseTemplatesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}