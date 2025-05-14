using System.Configuration;
using System.Text.Json;
using AmazonFbaFormUI.Dtos;

namespace AmazonFbaFormUI.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService()
        {
            var baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        public async Task<List<ProductQuickListDto>> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync("api/UsaToAuProduct");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var products = JsonSerializer.Deserialize<List<ProductQuickListDto>>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return products ?? new List<ProductQuickListDto>();
        }
    }
}
