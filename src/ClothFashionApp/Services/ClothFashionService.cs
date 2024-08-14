using ClothFashionApp.Models;

namespace ClothFashionApp.Services
{
    public class ClothFashionService
    {
        public IEnumerable<Item> GetPromoItems()
        {
            var result = new List<Item>();

            for (int i = 0; i < 10; i++)
            {
                result.Add(new Item { Id = 1, Image = "pantspio.jpg" });
                result.Add(new Item { Id = 2, Image = "coatgeremia.jpg" });
                result.Add(new Item { Id = 3, Image = "blazergloria.jpg" });
                result.Add(new Item { Id = 4, Image = "trouserskous.jpg" });
                result.Add(new Item { Id = 5, Image = "woolstriped.jpg" });
                result.Add(new Item { Id = 6, Image = "shirtfurio.jpg" }); 
                result.Add(new Item { Id = 7, Image = "sweatermarcello.jpg" });
                result.Add(new Item { Id = 8, Image = "shirtcroccante.jpg" });
            }

            return result;
        }

        public IEnumerable<string> GetCategories()
        {
            return new List<string>
            {
                "ALL",
                "NEW IN",
                "POPULAR",
                "WOMEN",
                "MAN"
            };
        }
        public Promotion GetPromotion()
        {
            return new Promotion
            {
                Title = "GET YOUR SPECIAL SALE",
                Discount = "UP TO 50%",
                Image = "promo.png",
                Button = "SHOP NOW"
            };
        }
         
        public IEnumerable<Product> GetPopularProducts()
        {
            return new List<Product>
            {
                new Product { Title = "PANTS PIO", Description = "CLEAN AND REFINED LINES FROM FINE FABRICS CHARACTERIZE THE KNITTED GARMENTS.", Image = "pantspio.jpg", Price = 124, Discount = 12, DiscountedPrice = 108, Rating = 4.5, Reviews = 1.5, Sales = 2.4 },
                new Product { Title = "COAT GEREMIA", Description = "ELEGANCE IS MADE OF SMALL GENTLE DETAILS AND PRECIOUS FABRICS FOR AN INCREASINGLY CHIC DAILY.", Image = "coatgeremia.jpg", Price = 350, Discount = 10, DiscountedPrice = 315, Rating = 4.6, Reviews = 1.1, Sales = 2.1 },
                new Product { Title = "BLAZER GLORIA", Description = "ELEGANCE IS MADE OF SMALL GENTLE DETAILS AND PRECIOUS FABRICS FOR AN INCREASINGLY CHIC DAILY.", Image = "blazergloria.jpg", Price = 247, Discount = 3, DiscountedPrice = 234, Rating = 3.9, Reviews = 1.1, Sales = 1.2 },
                new Product { Title = "TROUSERS KOUS", Description = "LOW HORSE TROUSERS IN CHECKED FLANNEL - 45% PC, 30% PL, 20% WO, 5% AF", Image = "trouserskous.jpg", Price = 94, Discount = 50, DiscountedPrice = 47, Rating = 4.0, Reviews = 1.6, Sales = 2.4 },
                new Product { Title = "WOOL STRIPED", Description = "UNISEX WOOL STRIPED SWEATER, A REVISITED CLASSIC.", Image = "woolstriped.jpg", Price = 135, Discount = 50, DiscountedPrice = 270, Rating = 4.2, Reviews = 1.7, Sales = 2.2 },
                new Product { Title = "SWEAT SHIRT FURIO", Description = "CLEAN AND REFINED LINES FROM FINE FABRICS CHARACTERIZE THE JERSEY AND SWEATSHIRT GARMENTS.", Image = "shirtfurio.jpg", Price = 104, Discount = 0, DiscountedPrice = 104, Rating = 3.7, Reviews = 1.3, Sales = 1.7 },
                new Product { Title = "SWEATER MARCELLO", Description = "ELEGANCE IS MADE OF SMALL GENTLE DETAILS AND PRECIOUS FABRICS FOR THE MOST CHIC LOOKS.", Image = "sweatermarcello.jpg", Price = 250, Discount = 10, DiscountedPrice = 225, Rating = 4.0, Reviews = 1.3, Sales = 1.9 },
                new Product { Title = "SHIRT CROCCANTE", Description = "ELEGANCE IS MADE OF SMALL GENTLE DETAILS AND PRECIOUS FABRICS FOR THE MOST CHIC AND BRILLIANT LOOKS.", Image = "shirtcroccante.jpg", Price = 146, Discount = 50, DiscountedPrice = 73, Rating = 4.6, Reviews = 1.0, Sales = 1.4 },
            };
        }
    }
}
