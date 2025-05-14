using AmazonFbaFormUI.Dtos;

namespace AmazonFbaFormUI.Services
{
    public interface IProductService
    {
        Task<List<ProductQuickListDto>> GetProductsAsync();
    }
}
