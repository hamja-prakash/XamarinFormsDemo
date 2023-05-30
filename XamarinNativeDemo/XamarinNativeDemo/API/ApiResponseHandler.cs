using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace XamarinNativeDemo.API
{
    public class ApiResponseHandler
    {
        public static async Task<T> HandleHttpResponse<T>(HttpResponseMessage responseMessage)
        {
            try
            {
                string jsonResult = responseMessage.Content != null ? await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false) : null;
                var resultEntity = JsonConvert.DeserializeObject<T>(jsonResult);
                if (responseMessage.IsSuccessStatusCode
                    || responseMessage.StatusCode == HttpStatusCode.NotFound
                    || responseMessage.StatusCode == HttpStatusCode.Forbidden
                    || responseMessage.StatusCode == HttpStatusCode.Unauthorized
                    || responseMessage.StatusCode == HttpStatusCode.BadRequest
                    || responseMessage.StatusCode == HttpStatusCode.InternalServerError)
                {
                    return resultEntity;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
