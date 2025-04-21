using AmazonFbaApi.Dtos.UsaToAudDto;
using AmazonFbaApi.Entities;

namespace AmazonFbaApi.Methods.Interfaces
{
    public interface IUsaToAuProducts
    {
        Task<List<ProductQuickListDto>> GetProductQuickListAsync();
        Task<ProductDetailDto> GetProductDetailAsync(int id);
        Task CreateProductAsync(CreateUsaToAuProductDto createUsaToAuProductDto);
        Task UpdateProductAsync(UpdateUsaToAuProductDto updateUsaToAuProductDto);
        Task DeleteProductAsync(int id);

    }
}
