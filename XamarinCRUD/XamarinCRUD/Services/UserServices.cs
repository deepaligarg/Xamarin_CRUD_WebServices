using Plugin.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinCRUD.Models;

namespace XamarinCRUD.Services
{
 public class UserServices
    {
        public async Task<List<User>> GetUsersAsync()
        {

            RestClient<User> restClient = new RestClient<User>();

            var usersList = await restClient.GetAsync();

            return usersList;
        }

        public async Task PostUserAsync(User user)
        {

            RestClient<User> restClient = new RestClient<User>();

            var usersList = await restClient.PostAsync(user);

        }
        public async Task PutUserAsync(int id, User user)
        {

            RestClient<User> restClient = new RestClient<User>();

            var usersList = await restClient.PutAsync1(id,user);

        }

        public async Task DeleteUserAsync(int id)
        {

            RestClient<User> restClient = new RestClient<User>();

            var usersList = await restClient.DeleteAsync(id);

        }
    }
    }
