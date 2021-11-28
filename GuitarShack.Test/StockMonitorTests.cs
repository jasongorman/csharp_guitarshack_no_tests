using Moq;
using Xunit;

namespace GuitarShack.Test
{
    public class StockMonitorTests
    {
        [Fact]
        public void ProductSold_AlertSent()
        {
            var mockAlert = new Mock<Alert>();
            Product product = new Product(811, 25);
            Warehouse warehouse = new StubWarehouse(product);
            RestockLevel restockLevel = new StubRestockLevel(24);
            StockMonitor monitor = new StockMonitor(mockAlert.Object, warehouse, restockLevel);
            monitor.HandleSale(811, 1);
            mockAlert.Verify(alert => alert.Send("Please order more of product 811"));
        }

        public class StubRestockLevel : RestockLevel
        {
            public StubRestockLevel(int level)
            {
            }
        }

        public class StubWarehouse : Warehouse
        {
            public StubWarehouse(Product product)
            {
            }
        }
    }

    public interface RestockLevel
    {
    }

    public interface Warehouse
    {
    }

    public class Product
    {
        public Product(int id, int stock)
        {
        }
    }

    public class StockMonitor
    {
        private readonly Alert _alert;

        public StockMonitor(Alert alert, Warehouse warehouse, RestockLevel restockLevel)
        {
            _alert = alert;
        }

        public void HandleSale(int productId, int saleQuantity)
        {
            _alert.Send("Please order more of product " + productId);
        }
    }

    public interface Alert
    {
        void Send(string message);
    }
}