using DevExpress.XamarinForms.CollectionView;
using FaksistentX.Services.UserSemesters.Dtos;
using FaksistentX.Shared.Controllers;
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
    public partial class UserSemestersPage : ContentPage
    {

        private UserSemestersViewModel viewModel;
        private UserSemestersController _userSemesterController;
        public UserSemestersPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new UserSemestersViewModel(this);

            _userSemesterController = new UserSemestersController();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            SemesterCollectionView.IsRefreshing = true;
            viewModel.OnAppearing();
            SemesterCollectionView.IsRefreshing = false;
        }

        private async void SwipeItem_Invoked(object sender, SwipeItemTapEventArgs e)
        {
            await _userSemesterController.DeleteUserSemester((e.Item as UserSemesterDto).Id);

            SemesterCollectionView.IsRefreshing = true;
            viewModel.OnAppearing();
            SemesterCollectionView.IsRefreshing = false;
        }

        private async void SwipeItem_Invoked_1(object sender, SwipeItemTapEventArgs e)
        {
            await _userSemesterController.SetIsSelected((e.Item as UserSemesterDto).Id);

            SemesterCollectionView.IsRefreshing = true;
            viewModel.OnAppearing();
            SemesterCollectionView.IsRefreshing = false;
        }

        private void SwipeItem_Invoked_2(object sender, SwipeItemTapEventArgs e)
        {
            viewModel.OnUpdate((e.Item as UserSemesterDto).Id);
        }
    }
}