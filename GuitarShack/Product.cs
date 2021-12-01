namespace GuitarShack
{
    public class Product
    {
        public Product(int id, int stock, int leadTime)
        {
            Id = id;
            Stock = stock;
            LeadTime = leadTime;
        }

        public int Id { get; }
        public int Stock { get; }
        public int LeadTime { get; }
    }
}