namespace StockApi.Models
{
    public class Box
    {
        public int ?Id { get; set; }
        public double WeightKg { get; set; }
        public int LengthCm { get; set; }
        public int HeightCm { get; set; }
        public int WidthCm { get; set; }
        public BoxContentType Content { get; set; }
        public int ItemCount { get; set; }
    } 
}
