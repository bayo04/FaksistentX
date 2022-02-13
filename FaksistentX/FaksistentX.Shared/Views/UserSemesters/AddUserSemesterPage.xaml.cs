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
    public partial class AddUserSemesterPage : ContentPage
    {
        private AddUserSemesterViewModel viewModel;
        public AddUserSemesterPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new AddUserSemesterViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}