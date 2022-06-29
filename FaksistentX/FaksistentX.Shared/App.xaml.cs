using FaksistentX.Shared.Actions;
using FaksistentX.Shared.Controllers;
using FaksistentX.Shared.Stores;
using FaksistentX.Shared.Views;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FaksistentX.Shared
{
    public partial class App : Application
    {

        public App()
        {
            DevExpress.XamarinForms.Editors.Initializer.Init();
            DevExpress.XamarinForms.CollectionView.Initializer.Init();
            DevExpress.XamarinForms.Navigation.Initializer.Init();
            DevExpress.XamarinForms.Charts.Initializer.Init();

            DependencyService.Register<Dispatcher>();

            DependencyService.Register<UserSemesterStore>();
            DependencyService.Register<UserStore>();

            DependencyService.Register<UserSemesterActions>();
            DependencyService.Register<UserActions>();

            InitializeComponent();

            MainPage = new LoginPage();

            RegisterRoutes();
        }

        public async Task RegisterRoutes()
        {
            var controllers = Assembly
               .GetAssembly(typeof(BaseController))
               .GetTypes()
               .Where(t => t.IsSubclassOf(typeof(BaseController)));

            foreach (var controller in controllers)
            {
                var controllerName = controller.Name.Replace("Controller", "");

                var methods = controller.GetMethods();

                foreach (var method in methods)
                {
                    var type = Type.GetType("FaksistentX.Shared.Views." + controllerName + "." + method.Name);
                    Routing.RegisterRoute(controllerName + "/" + method.Name, type);
                }
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
