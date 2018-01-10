namespace ListOfProducts
{
    public class Product
    {
        public Product(string p_productName, double p_price, int p_inventory)
        {
            ProductName = p_productName;
            Price = p_price;
            Inventory = p_inventory;
        }

        public override string ToString()
        {
            return ProductName + " " + Price + " " + Inventory;
        }

        public string ProductName { get; private set; }
        public double Price { get; private set; }
        public int Inventory { get; set; }
    }
}
