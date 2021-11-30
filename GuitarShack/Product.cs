namespace GuitarShack
{
    public class Product
    {
        public Product(int id, int stock)
        {
            Stock = stock;
        }

        public int Stock { get; }
    }
}