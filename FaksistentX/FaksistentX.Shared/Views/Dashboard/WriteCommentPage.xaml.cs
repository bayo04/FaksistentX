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
    public partial class WriteCommentPage : ContentPage
    {
        WriteCommentViewModel viewModel;
        public WriteCommentPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new WriteCommentViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}