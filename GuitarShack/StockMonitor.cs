namespace GuitarShack
{
    public class StockMonitor
    {
        private readonly IAlert _alert;
        private readonly IWarehouse _warehouse;
        private readonly IRestockLevel _restockLevel;

        public StockMonitor(IAlert alert, IWarehouse warehouse, IRestockLevel restockLevel)
        {
            _alert = alert;
            _warehouse = warehouse;
            _restockLevel = restockLevel;
        }

        public void HandleSale(int productId, int saleQuantity)
        {
            Product product = _warehouse.GetProduct(productId);
            
            if(product.Stock - saleQuantity <= _restockLevel.Calculate(product))
                _alert.Send("Please order more of product " + productId);
        }
    }
}