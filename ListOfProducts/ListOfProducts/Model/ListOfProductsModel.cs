using System.Collections.Generic;

namespace ListOfProducts
{
    /// The Model class. (BL)
    public class ListOfProductsModel
    {
        public List<Product> GetAllProducts()
        {
            return new List<Product>
            {
                new Product("TV", 3590.0, 120),
                new Product("Laptop", 5900.0, 30),
                new Product("Table", 1199.99, 53),
                new Product("Chair", 499.99, 32),
                new Product("Tablet", 2230.0, 4),
                new Product("Bed", 555.55, 1)
            };
        }
    }
}
