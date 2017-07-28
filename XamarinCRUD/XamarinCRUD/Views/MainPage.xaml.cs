using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinCRUD.Models;
using XamarinCRUD.ViewModels;
using XamarinCRUD.Views;

namespace XamarinCRUD
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new NewUserPage());
        }
        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var user = UsersListView.SelectedItem as User;

            if (user != null)
            {
                var mainViewModel = BindingContext as MainViewModel;

                if (mainViewModel != null)
                {
                    mainViewModel.SelectedUser = user;

                   await Navigation.PushAsync(new NewUserPage(mainViewModel));
                }
            }
        }

    }
}
