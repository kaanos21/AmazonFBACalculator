using AmazonFbaApi.Context;
using AmazonFbaApi.Dtos.UsaToAudDto;
using AmazonFbaApi.Entities;
using AmazonFbaApi.Methods.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AmazonFbaApi.Methods.Class
{
    public class UsaToAuProducts : IUsaToAuProducts
    {
        private readonly AmazonApiContext _context;

        public UsaToAuProducts(AmazonApiContext context)
        {
            _context = context;
        }

        public async Task CreateProductAsync(CreateUsaToAuProductDto createUsaToAuProductDto)
        {
            double costPerGramUnit = 6.55; //Per pound 8.5, Helium info
            double usdToAudRate = (double)UsdAudCurrency.UsdToAud / 1000; // Usa To Aud Rate
            double AudToUsd = (double)UsdAudCurrency.AudToUsd / 1000; // Usa To Aud Rate

            double fbaSalesFee = createUsaToAuProductDto.AuPrice * 0.13; //FbaSales Fee
            double shipmentPrice = createUsaToAuProductDto.WeightKg * costPerGramUnit + 0.88; //Total Shipment Price
            double ProductUsaPriceCurrencyAud = createUsaToAuProductDto.UsaPrice * usdToAudRate; // Usa Price with Aud currency

            double TotalEarnCurrencyAud = (createUsaToAuProductDto.AuPrice)
                - (fbaSalesFee) - (createUsaToAuProductDto.FbaFee)
                - (ProductUsaPriceCurrencyAud)
                - (shipmentPrice)-createUsaToAuProductDto.Surcharge;
            
            double TotalEarnCurrencyUsd=TotalEarnCurrencyAud*AudToUsd;

            double netProfit = TotalEarnCurrencyAud;

            double investmentCost = fbaSalesFee + shipmentPrice + ProductUsaPriceCurrencyAud;

            float roi = (float)(netProfit / investmentCost) * 100;

            UsaToAuProduct usaToAuProduct = new UsaToAuProduct()
            {
                Asin = createUsaToAuProductDto.Asin,
                AuPrice = createUsaToAuProductDto.AuPrice,
                UsaPrice = createUsaToAuProductDto.UsaPrice,
                WeightKg = createUsaToAuProductDto.WeightKg,
                FbaFee = createUsaToAuProductDto.FbaFee,
                Quantity=createUsaToAuProductDto.Quantity,
                Surcharge = createUsaToAuProductDto.Surcharge,
                Analysis=createUsaToAuProductDto.Analysis,
                FbaSalesFee=fbaSalesFee,
                ShipmentPrice=shipmentPrice,
                EarnAud=TotalEarnCurrencyAud,
                EarnUsd=TotalEarnCurrencyUsd,
                Roi=roi,
            };

            _context.UsaToAuProduct.Add(usaToAuProduct);
            _context.SaveChanges();
        }

        public async Task DeleteProductAsync(int id)
        {
            var value=_context.UsaToAuProduct.Find(id);
            _context.UsaToAuProduct.Remove(value);
            _context.SaveChanges();
        }

        public async Task<ProductDetailDto> GetProductDetailAsync(int id)
        {
            var result = _context.UsaToAuProduct.Find(id);

            ProductDetailDto resultDto = new ProductDetailDto()
            {
                Id = result.Id,
                Asin = result.Asin,
                AuPrice = result.AuPrice,
                UsaPrice = result.UsaPrice,
                WeightKg = result.WeightKg,
                FbaFee = result.FbaFee,
                Quantity = result.Quantity,
                Surcharge = result.Surcharge,
                FbaSalesFee = result.FbaSalesFee,
                ShipmentPrice = result.ShipmentPrice,
                EarnAud = result.EarnAud,
                EarnUsd = result.EarnUsd,
                Roi = result.Roi,
                Analysis=result.Analysis
            };
            return resultDto;
        }

        public async Task<List<ProductQuickListDto>> GetProductQuickListAsync()
        {
            var value=await _context.UsaToAuProduct.ToListAsync();

            var result = value.Select(product => new ProductQuickListDto
            {
                Id = product.Id,
                Asin = product.Asin,
                AuPrice = product.AuPrice,
                EarnAud = product.EarnAud,
                Quantity = product.Quantity,
                UsaPrice = product.UsaPrice,
                roi = product.Roi,
            }).ToList();

            return result;
        }

        public async Task UpdateProductAsync(UpdateUsaToAuProductDto updateUsaToAuProductDto)
        {
            double costPerGramUnit = 6.55; //Per pound 8.5, Helium info
            double usdToAudRate = (double)UsdAudCurrency.UsdToAud / 1000; // Usa To Aud Rate
            double AudToUsd = (double)UsdAudCurrency.AudToUsd / 1000; // Usa To Aud Rate

            double fbaSalesFee = updateUsaToAuProductDto.AuPrice * 0.13; //FbaSales Fee
            double shipmentPrice = updateUsaToAuProductDto.WeightKg * costPerGramUnit + 0.88; //Total Shipment Price
            double ProductUsaPriceCurrencyAud = updateUsaToAuProductDto.UsaPrice * usdToAudRate; // Usa Price with Aud currency

            double TotalEarnCurrencyAud = (updateUsaToAuProductDto.AuPrice)
                - (fbaSalesFee) - (updateUsaToAuProductDto.FbaFee)
                - (ProductUsaPriceCurrencyAud)
                - (shipmentPrice) - updateUsaToAuProductDto.Surcharge;

            double TotalEarnCurrencyUsd = TotalEarnCurrencyAud * AudToUsd;

            double netProfit = TotalEarnCurrencyAud;

            double investmentCost = fbaSalesFee + shipmentPrice + ProductUsaPriceCurrencyAud;

            float roi = (float)(netProfit / investmentCost) * 100;

            UsaToAuProduct usaToAuProduct = new UsaToAuProduct()
            {
                Asin = updateUsaToAuProductDto.Asin,
                AuPrice = updateUsaToAuProductDto.AuPrice,
                UsaPrice = updateUsaToAuProductDto.UsaPrice,
                WeightKg = updateUsaToAuProductDto.WeightKg,
                FbaFee = updateUsaToAuProductDto.FbaFee,
                Quantity = updateUsaToAuProductDto.Quantity,
                Surcharge = updateUsaToAuProductDto.Surcharge,
                Analysis=updateUsaToAuProductDto.Analysis,
                FbaSalesFee = fbaSalesFee,
                ShipmentPrice = shipmentPrice,
                EarnAud = TotalEarnCurrencyAud,
                EarnUsd = TotalEarnCurrencyUsd,
                Roi = roi,
            };

            _context.UsaToAuProduct.Update(usaToAuProduct);
            _context.SaveChanges();
        }
    }
}
