namespace GuitarShack
{
    public class Product
    {
        public Product(int id, int stock, int leadTime)
        {
            this.id = id;
            this.stock = stock;
            this.leadTime = leadTime;
        }

        public Product()
        {
        }

        public int id { get; set; }
        public int stock { get; set; }
        public int leadTime { get; set; }
    }
}