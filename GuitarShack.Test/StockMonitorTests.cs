using Moq;
using Xunit;

namespace GuitarShack.Test
{
    public class StockMonitorTests
    {
        [Fact]
        public void ProductSold_AlertSent()
        {
            var mockAlert = new Mock<IAlert>();
            Product product = new Product(811, 25);
            IWarehouse warehouse = new StubWarehouse(product);
            IRestockLevel restockLevel = new StubRestockLevel(24);
            StockMonitor monitor = new StockMonitor(mockAlert.Object, warehouse, restockLevel);
            monitor.HandleSale(811, 1);
            mockAlert.Verify(alert => alert.Send("Please order more of product 811"));
        }

        public class StubRestockLevel : IRestockLevel
        {
            public StubRestockLevel(int level)
            {
            }
        }

        public class StubWarehouse : IWarehouse
        {
            public StubWarehouse(Product product)
            {
            }
        }
    }
}