using FaksistentX.Services.Accounts.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FaksistentX.Shared.Actions
{
    public class UserActions
    {
        public void GetUser()
        {
            DependencyService.Get<Dispatcher>().Invoke<object>(UserActionTypes.GET_USER, null);
        }
        public void SetUser(UserDto input)
        {
            DependencyService.Get<Dispatcher>().Invoke<object>(UserActionTypes.SET_USER, input);
        }
    }

    public class UserActionTypes
    {
        public const string GET_USER = "get_user";

        public const string SET_USER = "set_user";
    }
}
