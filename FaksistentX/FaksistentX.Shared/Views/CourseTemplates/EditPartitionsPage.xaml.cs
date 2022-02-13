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
    public partial class EditPartitionsPage : ContentPage
    {
        private EditPartitionsViewModel viewModel;
        public EditPartitionsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new EditPartitionsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}