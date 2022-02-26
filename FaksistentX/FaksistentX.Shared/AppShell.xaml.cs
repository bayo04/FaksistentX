using FaksistentX.Shared.Controllers;
using FaksistentX.Shared.ViewModels;
using FaksistentX.Shared.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FaksistentX
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        private AppShellViewModel viewModel;
        public AppShell()
        {
            InitializeComponent();

            BindingContext = viewModel = new AppShellViewModel();
            viewModel.OnAppearing();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            viewModel.Logout();
        }
    }
}
