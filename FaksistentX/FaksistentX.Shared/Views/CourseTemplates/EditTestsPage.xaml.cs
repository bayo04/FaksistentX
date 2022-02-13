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
    public partial class EditTestsPage : ContentPage
    {
        private EditTestsViewModel viewModel;
        public EditTestsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new EditTestsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}