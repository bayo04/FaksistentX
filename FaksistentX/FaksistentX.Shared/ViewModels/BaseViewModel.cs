using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FaksistentX.Shared.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public void InvokeControllerMethod(string controllerName, string methodName, object parameters = null)
        {
            Type type = Type.GetType("FaksistentX.Shared.Controllers." + controllerName + "Controller");
            ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
            object classObject = constructor.Invoke(new object[] { });

            //https://stackoverflow.com/questions/11986947/how-to-map-json-string-to-the-calling-of-c-sharp-method
            MethodInfo method = type.GetMethod(methodName + "Page");
            if (parameters == null)
            {
                parameters = new
                {

                };
            }
            var parametersList = method.GetParameters()
                   .Select(p => parameters.GetType().GetProperty(p.Name) != null ? parameters.GetType().GetProperty(p.Name).GetValue(parameters) : default)
                   .ToArray();
            method.Invoke(classObject, parametersList);
        }

        public async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
