using FaksistentX.Shared.ViewModels;
using FaksistentX.Shared.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FaksistentX.Shared.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel viewModel;
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = viewModel = new LoginViewModel(this);
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