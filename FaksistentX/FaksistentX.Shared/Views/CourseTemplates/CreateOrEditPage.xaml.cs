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
    public partial class CreateOrEditPage : ContentPage
    {
        CreateOrEditViewModel viewModel;
        public CreateOrEditPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CreateOrEditViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}