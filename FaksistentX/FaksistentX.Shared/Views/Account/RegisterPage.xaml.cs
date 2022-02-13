using FaksistentX.Shared.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FaksistentX.Shared.Views.Account
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        private RegisterViewModel viewModel;
        public RegisterPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new RegisterViewModel(this);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }

        private void SimpleButton_Clicked(object sender, EventArgs e)
        {
            tenantPop.IsOpen = true;
        }

        public void ExitPopup()
        {
            tenantPop.IsOpen = false;
        }
    }
}