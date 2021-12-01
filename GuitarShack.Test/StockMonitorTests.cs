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
            Product product = new Product(811, 25, 14);
            IWarehouse warehouse = new StubWarehouse(product);
            IRestockLevel restockLevel = new StubRestockLevel(24);
            StockMonitor monitor = new StockMonitor(mockAlert.Object, warehouse, restockLevel);
            monitor.HandleSale(811, 1);
            mockAlert.Verify(alert => alert.Send("Please order more of product 811"));
        }
        
        [Fact]
        public void ProductSold_AlertNotSent()
        {
            var mockAlert = new Mock<IAlert>();
            Product product = new Product(811, 26, 14);
            IWarehouse warehouse = new StubWarehouse(product);
            IRestockLevel restockLevel = new StubRestockLevel(24);
            StockMonitor monitor = new StockMonitor(mockAlert.Object, warehouse, restockLevel);
            monitor.HandleSale(811, 1);
            mockAlert.Verify(alert => alert.Send(It.IsAny<string>()), Times.Never);
            
        }

        private class StubRestockLevel : IRestockLevel
        {
            private readonly int _level;

            public StubRestockLevel(int level)
            {
                _level = level;
            }

            public int Calculate(Product product)
            {
                return _level;
            }
        }

        private class StubWarehouse : IWarehouse
        {
            private readonly Product _product;

            public StubWarehouse(Product product)
            {
                _product = product;
            }

            public Product GetProduct(in int productId)
            {
                return _product;
            }
        }
    }
}