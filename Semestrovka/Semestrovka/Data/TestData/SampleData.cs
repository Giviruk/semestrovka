using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Data.TestData
{
    public class SampleData
    {
        public static void Initialize(ItemContext context)
        {
            if (!context.Items.Any())
            {
                context.Items.AddRange(
                    new Phone()
                    {
                        Name = "Galaxy S6",
                        Company = "Samsung",
                        Price = 1000,
                        Img = "/img/product-1.jpg"
                    },
                    new Phone()
                    {
                        Name = "Nokia Lumia 1320",
                        Company = "Samsung",
                        Price = 999,
                        Img = "/img/product-2.jpg"
                    },
                    new Phone()
                    {
                        Name = "LG Leon 2015",
                        Company = "PG",
                        Price = 425,
                        Img = "/img/product-3.jpg"
                    },
                    new Phone()
                    {
                        Name = "Sony microsoft",
                        Company = "PG",
                        Price = 225,
                        Img = "/img/product-4.jpg"
                    },
                    new Phone()
                    {
                        Name = "iPhone 6",
                        Company = "Apple",
                        Price = 1355,
                        Img = "/img/product-5.jpg"
                    },
                    new Phone()
                    {
                        Name = "Samsung gallaxy note 4",
                        Company = "Samsung",
                        Price = 400,
                        Img = "/img/product-6.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}