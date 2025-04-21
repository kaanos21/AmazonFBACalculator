namespace AmazonFbaUI.Dtos.UsaToAudDto
{
    public class ProductQuickListDto
    {
        public int Id { get; set; }
        public string Asin { get; set; }
        public int Quantity { get; set; }
        public double UsaPrice { get; set; }
        public double AuPrice { get; set; }
        public double EarnAud { get; set; }
        public float roi { get; set; }
    }
}
