using AmazonFbaApi.Dtos.UsaToAudDto;
using AmazonFbaApi.Entities;
using AmazonFbaApi.Methods.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmazonFbaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsaToAuProductController : ControllerBase
    {
        private readonly IUsaToAuProducts _usaToAuProducts;
        private readonly IAlAnalysis _alAnalysis;

        public UsaToAuProductController(IUsaToAuProducts usaToAuProducts, IAlAnalysis alAnalysis)
        {
            _usaToAuProducts = usaToAuProducts;
            _alAnalysis = alAnalysis;
        }

        [HttpGet]
        public async Task<IActionResult> UsaToAudGetProductQuickList()
        {
            var result = await _usaToAuProducts.GetProductQuickListAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> UsaToAudCreateProduct(CreateUsaToAuProductDto createUsaToAuProductDto)
        {
            await _usaToAuProducts.CreateProductAsync(createUsaToAuProductDto);
            return Ok("Başarıyla Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> UsaToAudDeleteProduct(int id)
        {
            await _usaToAuProducts.DeleteProductAsync(id);
            return Ok("Başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UsaToAudUpdateProduct(UpdateUsaToAuProductDto updateUsaToAuProductDto)
        {
            await _usaToAuProducts.UpdateProductAsync(updateUsaToAuProductDto);
            return Ok("Ürün Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(int id)
        {
            var value=await _usaToAuProducts.GetProductDetailAsync(id);
            return Ok(value);
        }
        [HttpGet("AlAnalysis")]
        public async Task<string> GetProductAnalysis(int id)
        {
            string AlAnalysisNode=await _alAnalysis.UsaToAudAlAnalysis(id);
            return AlAnalysisNode;
        }
    }
}
