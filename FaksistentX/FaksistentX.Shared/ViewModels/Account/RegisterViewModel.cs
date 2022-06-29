using FaksistentX.Services.Accounts;
using FaksistentX.Services.Accounts.Dtos;
using FaksistentX.Services.Tenants;
using FaksistentX.Services.Tenants.Dtos;
using FaksistentX.Shared.Views;
using FaksistentX.Shared.Views.Account;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace FaksistentX.Shared.ViewModels.Account
{
    public class RegisterViewModel : BaseViewModel
    {
        private string _username;
        private string _password;
        private string _passwordConfirmed;
        private string _firstName;
        private string _lastName;
        private string _email;
        public Command RegisterCommand { get; }

        private readonly AccountAppService _accountAppService;

        private string _changeTenantText;

        private RegisterPage _page { get; set; }

        private TenantDto _selectedTenant { get; set; }

        private readonly TenantAppService _tenantAppService;
        public Command<TenantDto> TenantChanged { get; }

        public ObservableCollection<TenantDto> Tenants { get; set; }

        public RegisterViewModel(RegisterPage page)
        {
            RegisterCommand = new Command(OnRegisterClicked);
            TenantChanged = new Command<TenantDto>(OnTenantChange);

            _accountAppService = new AccountAppService();
            _tenantAppService = new TenantAppService();

            _page = page;

            Tenants = new ObservableCollection<TenantDto>();
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

        public string PasswordConfirmed
        {
            get => _passwordConfirmed;
            set => SetProperty(ref _passwordConfirmed, value);
        }

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string ChangeTenantText
        {
            get => _changeTenantText;
            set => SetProperty(ref _changeTenantText, value);
        }

        public async void OnAppearing()
        {
            var tenants = await _tenantAppService.GetAllAsync();

            foreach (var tenant in tenants)
            {
                Tenants.Add(tenant);
            }

            _selectedTenant = await _tenantAppService.GetSelectedTenant();
            ChangeTenantText = _selectedTenant == null ? "Studij nije odabran, klikni ovdje" : _selectedTenant.TenancyName + " - klikni za promjenu";
        }

        private async void OnRegisterClicked(object obj)
        {
            var success = await _accountAppService.Register(new RegisterInput
            {
                Name = _firstName,
                Password = _password,
                Surname = _lastName,
                UserName = _username,
                EmailAddress = _email
            });

            if (success)
            {
                Application.Current.MainPage = new LoginPage();
            }
        }

        private async void OnTenantChange(TenantDto tenant)
        {
            await _tenantAppService.SelectTenant(tenant.Id);
            _selectedTenant = tenant;
            ChangeTenantText = _selectedTenant == null ? "Studij nije odabran, klikni ovdje" : _selectedTenant.TenancyName + " - klikni za promjenu";

            _page.ExitPopup();
        }
    }
}
