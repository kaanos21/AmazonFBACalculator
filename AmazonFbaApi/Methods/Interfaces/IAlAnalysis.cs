using AmazonFbaApi.Dtos.UsaToAudDto;

namespace AmazonFbaApi.Methods.Interfaces
{
    public interface IAlAnalysis
    {
        Task<string> UsaToAudAlAnalysis(int id);
    }
}
