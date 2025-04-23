using AmazonFbaApi.Dtos.UsaToAudDto;
using AmazonFbaApi.Entities;
using AmazonFbaApi.Methods.Interfaces;
using System.Text.Json;
using System.Text;
using AmazonFbaApi.Context;

namespace AmazonFbaApi.Methods.Class
{
    public class AlAnalysis : IAlAnalysis
    {
        private readonly AmazonApiContext _context;

        public AlAnalysis(AmazonApiContext context)
        {
            _context = context;
        }

        public async Task<string> UsaToAudAlAnalysis(int id)
        {
            var apiKey = "Your Api Key";

            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var value=_context.UsaToAuProduct.Find(id);

            ProductAlAnalysisDto productAlAnalysisDto = new ProductAlAnalysisDto()
            {
                UsaPrice = value.UsaPrice,
                AuPrice = value.AuPrice,
                EarnAud = value.EarnAud,
                Roi = value.Roi,
                Analysis = value.Analysis,
            };


            double usdToAudRate = (double)UsdAudCurrency.UsdToAud / 1000;

            double UsaPrice= productAlAnalysisDto.UsaPrice*usdToAudRate;
            double AudPrice = productAlAnalysisDto.AuPrice;
            double EarnAud= productAlAnalysisDto.EarnAud;
            float roi= productAlAnalysisDto.Roi;

            string AnalysisNode = productAlAnalysisDto.Analysis;

            string prompt = "ürünü amerikadan "+UsaPrice+" aud dolarına alıyorum, satış fiyatım:"+AudPrice+" bu üründen ettiğim kar miktarı ve roi: "+EarnAud+" "+roi+
                "karlılık hesaplaması zaten yapılı onu boşver, eğer ürünü satan çok fazla satıcı ve stok miktarları kötüye işarettir çünkü amazonun bana" +
                "buybox verme ihtimali azalır, amacımız satış hacmi yüksek ve bu satışlardan pay alabileceğimiz ürünler bulmak, aldığım notlara göre" +
                "bu üründe buy box alabilirmiyim alamazmıyım yorumla ve 10 üzerinden bir puan ver, işte aldığım not: "+AnalysisNode;

            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
            {
                new {role="system",content="You are a helpful assistant."},
                new {role="user",content=prompt}
            },
                max_tokens = 1000
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonSerializer.Deserialize<JsonElement>(responseString);
                    var answer = result.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
                    return answer;
                }
                else
                {
                    return "Bir hata oluştu";
                }
            }
            catch (Exception ex)
            {

                return "Bir hata oluştu";
            }

            
        }
    }
}
