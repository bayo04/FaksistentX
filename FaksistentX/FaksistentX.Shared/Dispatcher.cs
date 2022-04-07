using FaksistentX.Shared.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FaksistentX.Shared
{
    public class Dispatcher
    {
        public UserSemesterStore _userSemesterStore { get; set; }
        public Dispatcher()
        {
        }
        public void Invoke<TData>(string eventType, TData data)
        {
            _userSemesterStore = DependencyService.Get<UserSemesterStore>();

            _userSemesterStore.Invoke<TData>(eventType, data);
        }
    }
}
