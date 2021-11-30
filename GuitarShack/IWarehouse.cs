namespace GuitarShack
{
    public interface IWarehouse
    {
        Product GetProduct(in int productId);
    }
}