namespace GuitarShack.Test
{
    public class StockMonitor
    {
        private readonly IAlert _alert;

        public StockMonitor(IAlert alert, IWarehouse warehouse, IRestockLevel restockLevel)
        {
            _alert = alert;
        }

        public void HandleSale(int productId, int saleQuantity)
        {
            _alert.Send("Please order more of product " + productId);
        }
    }
}