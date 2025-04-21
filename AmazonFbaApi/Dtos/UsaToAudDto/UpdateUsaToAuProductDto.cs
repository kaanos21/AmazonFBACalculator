namespace AmazonFbaApi.Dtos.UsaToAudDto
{
    public class UpdateUsaToAuProductDto
    {
        public string Asin { get; set; }
        public double FbaFee { get; set; }
        public int Quantity { get; set; }
        public double UsaPrice { get; set; }
        public double AuPrice { get; set; }
        public double WeightKg { get; set; }
        public double Surcharge { get; set; }
        public string Analysis { get; set; }
    }
}
