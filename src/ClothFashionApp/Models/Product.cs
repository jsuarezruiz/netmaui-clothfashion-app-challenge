namespace ClothFashionApp.Models
{
    public class Product : Item
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public double DiscountedPrice { get; set; }
        public double Rating { get; set; }
        public double Reviews { get; set; }
        public double Sales { get; set; }
        public IEnumerable<string> Sizes { get; set; } = new List<string> { "S", "M", "L", "XL", "XXL" };
        public bool Favorite { get; set; }
    }
}
