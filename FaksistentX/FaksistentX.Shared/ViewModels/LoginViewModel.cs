using DevExpress.XamarinForms.Popup;
using FaksistentX.Services;
using FaksistentX.Services.Accounts;
using FaksistentX.Services.Base;
using FaksistentX.Services.Tenants;
using FaksistentX.Services.Tenants.Dtos;
using FaksistentX.Shared.Actions;
using FaksistentX.Shared.Stores;
using FaksistentX.Shared.Views;
using FaksistentX.Shared.Views.Account;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FaksistentX.Shared.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        private string _password;

        private string _changeTenantText;

        public Command LoginCommand { get; }
        public Command OnRegisterCommand { get; }

        private readonly AccountAppService _accountAppService;

        private readonly TenantAppService _tenantAppService;

        private readonly UserSemesterActions _userSemesterActions;
        private readonly UserActions _userActions;

        public Command<TenantDto> TenantChanged { get; }

        public ObservableCollection<TenantDto> Tenants { get; set; }

        private LoginPage _page { get; set; }

        private TenantDto _selectedTenant { get; set; }

        public LoginViewModel(LoginPage page)
        {
            LoginCommand = new Command(OnLoginClicked);
            OnRegisterCommand = new Command(OnRegisterClicked);
            TenantChanged = new Command<TenantDto>(OnTenantChange);

            _accountAppService = new AccountAppService();
            _tenantAppService = new TenantAppService();

            _page = page;

            Tenants = new ObservableCollection<TenantDto>();

            _userSemesterActions = DependencyService.Get<UserSemesterActions>();
            _userActions = DependencyService.Get<UserActions>();
        }

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string ChangeTenantText
        {
            get => _changeTenantText;
            set => SetProperty(ref _changeTenantText, value);
        }

        public async void OnAppearing()
        {
            var loggedIn = await _accountAppService.GetCurrentLoginInformations();

            if (loggedIn)
            {
                _userSemesterActions.GetCurrentSemester();

                _userActions.GetUser();

                Application.Current.MainPage = new AppShell();
            }

            var tenants = await _tenantAppService.GetAllAsync();

            foreach(var tenant in tenants)
            {
                Tenants.Add(tenant);
            }

            _selectedTenant = await _tenantAppService.GetSelectedTenant();
            ChangeTenantText = _selectedTenant == null ? "Studij nije odabran, klikni ovdje" : _selectedTenant.TenancyName + " - klikni za promjenu";
        }

        private async void OnLoginClicked(object obj)
        {
            var user = await _accountAppService.Login(Username, Password);

            if (user != null)
            {
                _userSemesterActions.GetCurrentSemester();

                _userActions.SetUser(user);

                Application.Current.MainPage = new AppShell();
            }
        }
        
        private async void OnRegisterClicked(object obj)
        {
            Application.Current.MainPage = new RegisterPage();
        }

        private async void OnTenantChange(TenantDto tenant)
        {
            await _tenantAppService.SelectTenant(tenant.Id);
            _selectedTenant = tenant;
            ChangeTenantText = _selectedTenant == null ? "Tenant not selected, click here" : _selectedTenant.TenancyName + " - Click to change";

            _page.ExitPopup();
        }
    }
}
