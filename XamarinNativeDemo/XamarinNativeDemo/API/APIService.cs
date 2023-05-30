using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XamarinNativeDemo.Model;

namespace XamarinNativeDemo.API
{
    public class APIService
    {
        private HttpClient CreateHttpClient(string authToken)
        {
            var handler = new HttpClientHandler();
            //handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            //{
            //    if (cert.Issuer.Equals("CN=localhost"))
            //        return true;
            //    return errors == System.Net.Security.SslPolicyErrors.None;
            //};
            handler.ServerCertificateCustomValidationCallback +=
                (sender, certificate, chain, errors) =>
                {
                    return true;
                };

            var httpClient = new HttpClient(handler);
            httpClient.Timeout = TimeSpan.FromMinutes(10);
            httpClient.BaseAddress = new Uri(ApiConstant.BaseApiUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("x-api-key", "8d5700521ec2464d9c419709b862bf22");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "android user agent");

            //httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("android user agent"));
            return httpClient;
        }

        private async Task<T> HandleException<T>(Exception e)
        {
            Debug.WriteLine($"{e.GetType().Name + " : " + e.Message}");
            throw e;
        }

        public async Task<T> GetAsync<T>(string uri, string authToken = "")
        {
            try
            {
                if (!ConnectionService.IsConnected())
                    return default;

                HttpClient httpClient = CreateHttpClient(authToken);
                var responseMessage = await httpClient.GetAsync(uri).ConfigureAwait(false);
                return await ApiResponseHandler.HandleHttpResponse<T>(responseMessage);
            }
            catch (Exception e)
            {
                return await HandleException<T>(e);
            }
        }

        public async Task<T> DeleteAsync<T>(string uri, string authToken = "")
        {
            try
            {
                if (!ConnectionService.IsConnected())
                    return default;

                HttpClient httpClient = CreateHttpClient(authToken);
                var responseMessage = await httpClient.DeleteAsync(uri).ConfigureAwait(false);
                return await ApiResponseHandler.HandleHttpResponse<T>(responseMessage);
            }
            catch (Exception e)
            {
                return await HandleException<T>(e);
            }
        }

        public async Task<T> PostAsync<T>(string uri, T data, string authToken = "")
        {
            try
            {
                if (!ConnectionService.IsConnected())
                    return default;

                HttpClient httpClient = CreateHttpClient(authToken);

                var content = new StringContent(JsonConvert.SerializeObject(data));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var responseMessage = await httpClient.PostAsync(uri, content).ConfigureAwait(false);
                return await ApiResponseHandler.HandleHttpResponse<T>(responseMessage);
            }
            catch (Exception e)
            {
                return await HandleException<T>(e);
            }
        }

        public async Task<TR> PostAsync<T, TR>(string uri, T data, string authToken = "")
        {
            try
            {
                if (!ConnectionService.IsConnected())
                    return default;

                HttpClient httpClient = CreateHttpClient(authToken);
                var jsonString = JsonConvert.SerializeObject(data);
                var content = new StringContent(jsonString);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                string jsonResult = string.Empty;
                var responseMessage = await httpClient.PostAsync(uri, content).ConfigureAwait(false);
                return await ApiResponseHandler.HandleHttpResponse<TR>(responseMessage);
            }
            catch (Exception e)
            {
                return await HandleException<TR>(e);
            }
        }

        public async Task<T> PutAsync<T>(string uri, T data, string authToken = "")
        {
            try
            {
                if (!ConnectionService.IsConnected())
                    return default;

                HttpClient httpClient = CreateHttpClient(authToken);
                var content = new StringContent(JsonConvert.SerializeObject(data));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var responseMessage = await httpClient.PutAsync(uri, content).ConfigureAwait(false);
                return await ApiResponseHandler.HandleHttpResponse<T>(responseMessage);
            }
            catch (Exception e)
            {
                return await HandleException<T>(e);
            }
        }

        public async Task DeleteAsync(string uri, string authToken = "")
        {
            HttpClient httpClient = CreateHttpClient(authToken);
            await httpClient.DeleteAsync(uri);
        }

        public async Task<T> SendAsync<T>(string uri, object reqParams, HttpMethod method, string authToken = "")
        {
            try
            {
                if (!ConnectionService.IsConnected())
                    return default;

                HttpClient httpClient = CreateHttpClient(authToken);
                string jsonResult = string.Empty;
                string requestBody = JsonConvert.SerializeObject(reqParams);
                var request = new HttpRequestMessage
                {
                    Method = method,
                    RequestUri = new Uri(Path.Combine(ApiConstant.BaseApiUrl, uri)),
                    Content = new StringContent(requestBody, Encoding.UTF8, "application/json"),
                };
                var responseMessage = await httpClient.SendAsync(request).ConfigureAwait(false);
                return await ApiResponseHandler.HandleHttpResponse<T>(responseMessage);
            }
            catch (Exception e)
            {
                return await HandleException<T>(e);
            }
        }

        public async Task<TR> SendAsync<T, TR>(string uri, object reqParams, HttpMethod method, string authToken = "")
        {
            try
            {
                if (!ConnectionService.IsConnected())
                    return default;

                HttpClient httpClient = CreateHttpClient(authToken);
                string jsonResult = string.Empty;
                string requestBody = JsonConvert.SerializeObject(reqParams);
                var request = new HttpRequestMessage
                {
                    Method = method,
                    RequestUri = new Uri(Path.Combine(ApiConstant.BaseApiUrl, uri)),
                    Content = new StringContent(requestBody, Encoding.UTF8, "application/json"),
                };
                var responseMessage = await httpClient.SendAsync(request).ConfigureAwait(false);
                return await ApiResponseHandler.HandleHttpResponse<TR>(responseMessage);
            }
            catch (Exception e)
            {
                return await HandleException<TR>(e);
            }
        }

        //public async Task<TR> PostImageAsync<T, TR>(string uri, T data, string authToken = "")
        //{
        //    try
        //    {
        //        if (data is Model.API.UploadProfile uploadProfile)
        //        {
        //            if (!ConnectionService.IsConnected())
        //                return default;
        //            HttpClient httpClient = CreateHttpClient(authToken);

        //            MultipartFormDataContent multiContent = new MultipartFormDataContent();
        //            HttpContent fileStreamContent1 = new StreamContent(new MemoryStream(uploadProfile.file));
        //            fileStreamContent1.Headers.ContentDisposition = new
        //            System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
        //            {
        //                Name = "File",
        //                FileName = "ProfileImage.png"
        //            };
        //            fileStreamContent1.Headers.ContentType = new
        //            System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
        //            multiContent.Add(fileStreamContent1);

        //            multiContent.Add(new StringContent(uploadProfile.userExId), "userExId");

        //            var responseMessage = await httpClient.PostAsync(uri, multiContent).ConfigureAwait(false);
        //            return await ApiResponseHandler.HandleHttpResponse<TR>(responseMessage);
        //        }

        //        return default(TR);
        //    }
        //    catch (Exception e)
        //    {
        //        return await HandleException<TR>(e);
        //    }
        //}
    }
}
