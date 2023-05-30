using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinNativeDemo.Model;
using XamarinNativeDemo.Model.Product;

namespace XamarinNativeDemo.API
{
    public class ProductAPI
    {
        public APIService aPIService = new APIService();

        public async Task<List<Product>> GetProducts()
        {
            return await aPIService.GetAsync<List<Product>>(string.Format(ApiConstant.GetProducts));
        }

        public async Task<Product> DeleteProductByProductId(int productId)
        {
            return await aPIService.DeleteAsync<Product>(string.Format(ApiConstant.DeleteProductById, productId));
        }

        public async Task<Product> ProductDetailsByProductId(int productId)
        {
            return await aPIService.GetAsync<Product>(string.Format(ApiConstant.ProductDetailsById, productId));
        }

        public async Task<Product> InsertProduct(ProductRequest productRequest)
        {
            return await aPIService.PostAsync<ProductRequest,Product>(ApiConstant.InsertProduct,productRequest);
        }
    }
}
