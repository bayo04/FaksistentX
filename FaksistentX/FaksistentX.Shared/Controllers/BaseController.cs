using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FaksistentX.Shared.Controllers
{
    public class BaseController
    {
        protected async Task ChangeView(object model = null, bool isJson = false, string methodName = "", string controllerName = "",
            [CallerMemberName] string callerName = "", [CallerFilePath] string callerClass = "")
        {
            if (methodName == "")
            {
                methodName = callerName;
            }
            if (string.IsNullOrEmpty(controllerName))
            {
                var split = callerClass.Split('\\');
                controllerName = split[split.Length - 1];
                controllerName = controllerName.Replace("Controller.cs", "");
            }
            string query = "";
            if (model != null)
            {
                if (isJson)
                {
                    query = "?JsonValue=" + JsonConvert.SerializeObject(model);
                }
                else
                {
                    query = "?" + ToQueryString(model);
                }
            }
            await Shell.Current.GoToAsync($"{controllerName}/{methodName}{query}");
        }

        //https://stackoverflow.com/questions/6848296/how-do-i-serialize-an-object-into-query-string-format
        private string ToQueryString(object request, string separator = ",")
        {
            if (request == null)
                throw new ArgumentNullException("request");

            // Get all properties on the object
            var properties = request.GetType().GetProperties()
                .Where(x => x.CanRead)
                .Where(x => x.GetValue(request, null) != null)
                .ToDictionary(x => x.Name, x => x.GetValue(request, null));

            // Get names for all IEnumerable properties (excl. string)
            var propertyNames = properties
                .Where(x => !(x.Value is string) && x.Value is IEnumerable)
                .Select(x => x.Key)
                .ToList();

            // Concat all IEnumerable properties into a comma separated string
            foreach (var key in propertyNames)
            {
                var valueType = properties[key].GetType();
                var valueElemType = valueType.IsGenericType
                                        ? valueType.GetGenericArguments()[0]
                                        : valueType.GetElementType();
                if (valueElemType.IsPrimitive || valueElemType == typeof(string))
                {
                    var enumerable = properties[key] as IEnumerable;
                    properties[key] = string.Join(separator, enumerable.Cast<object>());
                }
            }

            // Concat all key/value pairs into a string separated by ampersand
            return string.Join("&", properties
                .Select(x => string.Concat(
                    Uri.EscapeDataString(x.Key), "=",
                    Uri.EscapeDataString(x.Value.ToString()))));
        }
    }
}
