namespace AmazonFbaApi.Entities
{
    public class UsaToAuProduct
    {
        public int Id { get; set; }
        public string Asin {  get; set; }
        public double FbaFee { get; set; }
        public double FbaSalesFee {  get; set; }
        public double ShipmentPrice { get; set; }
        public int Quantity { get; set; }
        public double UsaPrice { get; set; }
        public double AuPrice { get; set; }
        public double WeightKg { get; set; }
        public double EarnAud {  get; set; }
        public double EarnUsd { get; set; }
        public float Roi {  get; set; }
        public double Surcharge { get; set; }
        public string? Analysis {  get; set; }
    }
}
