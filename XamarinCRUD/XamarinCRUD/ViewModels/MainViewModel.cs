using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinCRUD.Models;
using XamarinCRUD.Services;

namespace XamarinCRUD.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<User> _usersList;
        private User _selectedUser;

        public List<User> UsersList {
            get {return _usersList; }
            set {
                _usersList = value;
                OnPropertychanged();
            }
        }

        public User SelectedUser
        {
            get { return _selectedUser; }
            set { _selectedUser = value;
                OnPropertychanged();
            }
        }

        public Command PostingCommand{
            get
            {
                return new Command(async () =>
                {
                    var userServices = new UserServices();
                  await userServices.PostUserAsync(_selectedUser);
                });
            }
        }

        public Command PutCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var userServices = new UserServices();
                    await userServices.PutUserAsync(_selectedUser.Id,_selectedUser);
                });
            }
        }

        public Command DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var userServices = new UserServices();
                    await userServices.DeleteUserAsync(_selectedUser.Id);
                });
            }
        }

        public MainViewModel()
        {
            
            InitializeDataAsync();
        }

        private async Task InitializeDataAsync()
        {
            var userServices = new UserServices();

            UsersList = await userServices.GetUsersAsync();
          
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertychanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
