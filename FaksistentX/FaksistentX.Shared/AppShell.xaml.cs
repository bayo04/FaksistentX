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

            //BindingContext = viewModel = new AppShellViewModel();
        }

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);

            (BindingContext as AppShellViewModel).OnAppearing();

            //viewModel.OnAppearing();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //(BindingContext as AppShellViewModel).OnAppearing();

            //viewModel.OnAppearing();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            (BindingContext as AppShellViewModel).Logout();
            //viewModel.Logout();
        }
    }
}
