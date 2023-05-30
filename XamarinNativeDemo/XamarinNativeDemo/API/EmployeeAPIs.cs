using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinNativeDemo.Model;
using XamarinNativeDemo.Views;

namespace XamarinNativeDemo.API
{
    public class EmployeeAPIs
    {
        public APIService aPIService = new APIService();
        //public async Task<EmployeeListner> GetEmployees()
        //{
        //    return await aPIService.GetAsync<EmployeeListner>(string.Format(ApiConstant.GetEmployees));
        //}
    }
}
