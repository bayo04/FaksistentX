using FaxistentX.Core.Base;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FaksistentX.Services.Base
{
    public class BaseAppService
    {
        protected async Task<JsonRoot<TReturn>> GetAsync<TReturn>(string extension, object data = null)
        {
            string responseString;
            string url = AppConsts.ApiUrl + extension;

            if (data != null)
            {
                url += "?" + ToQueryString(data);
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.Method = "GET";
            request.ContentType = "application/json";

            request.ServerCertificateValidationCallback = delegate { return true; };

            var token = await SecureStorage.GetAsync("accessToken");

            request.Headers.Add("Authorization", $"Bearer {token}");

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                responseString = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<JsonRoot<TReturn>>(responseString);
        }
        protected async Task<JsonRootList<TReturn>> GetListAsync<TReturn>(string extension, object data = null)
        {
            string responseString;
            string url = AppConsts.ApiUrl + extension;

            if (data != null)
            {
                url += "?" + ToQueryString(data);
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.Method = "GET";
            request.ContentType = "application/json";

            request.ServerCertificateValidationCallback = delegate { return true; };

            var token = await SecureStorage.GetAsync("accessToken");

            request.Headers.Add("Authorization", $"Bearer {token}");

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                responseString = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<JsonRootList<TReturn>>(responseString);
        }

        protected async Task<JsonRoot<TReturn>> PostAsync<TReturn>(string extension, object data = null)
        {
            string responseString;
            string url = AppConsts.ApiUrl + extension;
            Uri baseUri = new Uri(AppConsts.ApiUrl);
            Uri uri = new Uri(baseUri, extension);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.Method = "POST";
            request.ContentType = "application/json";

            request.ServerCertificateValidationCallback = delegate { return true; };

            var token = await SecureStorage.GetAsync("accessToken");

            request.Headers.Add("Authorization", $"Bearer {token}");

            var json = JsonConvert.SerializeObject(data);
            var requestData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));

            using (var stream = request.GetRequestStream())
            {
                stream.Write(requestData, 0, requestData.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                responseString = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<JsonRoot<TReturn>>(responseString);
        }

        protected async Task<JsonRootList<TReturn>> PostListAsync<TReturn>(string extension, object data = null)
        {
            string responseString;
            string url = AppConsts.ApiUrl + extension;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.Method = "POST";
            request.ContentType = "application/json";

            request.ServerCertificateValidationCallback = delegate { return true; };

            var token = await SecureStorage.GetAsync("accessToken");

            request.Headers.Add("Authorization", $"Bearer {token}");

            var json = JsonConvert.SerializeObject(data);
            var requestData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));

            using (var stream = request.GetRequestStream())
            {
                stream.Write(requestData, 0, requestData.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                responseString = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<JsonRootList<TReturn>>(responseString);
        }

        protected async Task<JsonRoot<TReturn>> DeleteAsync<TReturn>(string extension, object data = null)
        {
            string responseString;
            string url = AppConsts.ApiUrl + extension;

            if(data != null)
            {
                url += "?" + ToQueryString(data);
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.Method = "DELETE";
            request.ContentType = "application/json";

            request.ServerCertificateValidationCallback = delegate { return true; };

            var token = await SecureStorage.GetAsync("accessToken");

            request.Headers.Add("Authorization", $"Bearer {token}");

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                responseString = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<JsonRoot<TReturn>>(responseString);
        }

        protected async Task<JsonRoot<TReturn>> PutAsync<TReturn>(string extension, object data = null)
        {
            string responseString;
            string url = AppConsts.ApiUrl + extension;
            Uri baseUri = new Uri(AppConsts.ApiUrl);
            Uri uri = new Uri(baseUri, extension);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.Method = "PUT";
            request.ContentType = "application/json";

            request.ServerCertificateValidationCallback = delegate { return true; };

            var token = await SecureStorage.GetAsync("accessToken");

            request.Headers.Add("Authorization", $"Bearer {token}");

            var json = JsonConvert.SerializeObject(data);
            var requestData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));

            using (var stream = request.GetRequestStream())
            {
                stream.Write(requestData, 0, requestData.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                responseString = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<JsonRoot<TReturn>>(responseString);
        }

        protected string ToQueryString(object request, string separator = ",")
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
