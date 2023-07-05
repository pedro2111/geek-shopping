using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using System.Net.Http;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services
{  
    public class ProductService : IProductService
    {    
        private readonly HttpClient _httpClient;
        public const string basePath = "api/v1/product";

        public ProductService(HttpClient httpClient){

            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            var response = await _httpClient.GetAsync(basePath);
            Console.WriteLine("teste response: " + $"{response}");

            return await response.ReadContentAS<List<ProductModel>>();
        }
        public async Task<ProductModel> FindProductsById(long id)
        {
            var response = await _httpClient.GetAsync($"{basePath}/{id}");
            
            return await response.ReadContentAS<ProductModel>();
        }
        public async Task<ProductModel> CreateProduct(ProductModel model)
        {
            var response = await _httpClient.PostAsJson(basePath, model);

            if(!response.IsSuccessStatusCode) return await response.ReadContentAS<ProductModel>();

            else throw new Exception("Aconteceu algo de errado ao chamar a api de post");
        }
        public async Task<ProductModel> UpdateProduct(ProductModel model)
        {
             var response = await _httpClient.PutAsJson(basePath, model);

            if(!response.IsSuccessStatusCode) return await response.ReadContentAS<ProductModel>();

            else throw new Exception("Aconteceu algo de errado ao chamar a api");
        }
        public async Task<bool> DeleteProductById(long id)
        {
             var response = await _httpClient.DeleteAsync($"{basePath}/{id}");
            if(!response.IsSuccessStatusCode) return await response.ReadContentAS<bool>();

            else throw new Exception("Aconteceu algo de errado ao chamar a api");
        }
    }
}