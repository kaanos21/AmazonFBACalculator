using AmazonFbaApi.Methods.Class;
using AmazonFbaApi.Methods.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AmazonFbaApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMethodDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUsaToAuProducts, UsaToAuProducts>();
            services.AddScoped<IAlAnalysis, AlAnalysis>();

            return services;
        }
    }
}
