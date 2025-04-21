using AmazonFbaUI.Dtos.UsaToAudDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AmazonFbaUI.Controllers
{
    public class ProductUsaToAudController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductUsaToAudController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> ProductQuickList()
        {
            var client=_httpClientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync("UsaToAuProduct");

            if(response.IsSuccessStatusCode)
            {
                var jsonData=await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ProductQuickListDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> ProductDetail(int id)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            var response = await client.GetAsync($"UsaToAuProduct/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<ProductDetailDto>(jsonData);
                return View(product);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateUsaToAuProductDto createUsaToAuProductDto)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            var jsonData = JsonConvert.SerializeObject(createUsaToAuProductDto);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync("UsaToAuProduct", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductQuickList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            var response = await client.DeleteAsync($"UsaToAuProduct?id={id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductQuickList");
            }

            return View("ProductQuickList");
        }

        public async Task<IActionResult> AlProductAnalysis(int id)
        {
            var client = _httpClientFactory.CreateClient("ApiClient");

            // API'ye GET isteği gönderiyoruz
            var response = await client.GetAsync($"UsaToAuProduct/AlAnalysis?id={id}");

            if (response.IsSuccessStatusCode)
            {
                // API'den dönen veriyi alıyoruz
                var analysis = await response.Content.ReadAsStringAsync();

                // JSON formatında dönecek veriyi view'a taşıyoruz
                return Json(new { success = true, analysis = analysis });
            }
            else
            {
                return Json(new { success = false, message = "Analysis verisi alınırken bir hata oluştu." });
            }
        }




    }
}
