using System;
using Xunit;

namespace GuitarShack.Test
{
    public class RestockLevelTests
    {
        [Fact]
        public void CalculatedAsProductLeadTimeTimesAverageDailySales()
        {
            ISalesHistory salesHistory = new StubSalesHistory(15);
            IRestockLevel restockLevel = new ProductRestockLevel(salesHistory);
            Product product = new Product(811, 0, 14);
            Assert.Equal(7, restockLevel.Calculate(product));
        }
    }

    public class StubSalesHistory : ISalesHistory
    {
        private readonly int _totalSales;

        public StubSalesHistory(int totalSales)
        {
            _totalSales = totalSales;
        }

        public int Total(int productId, DateTime startDate, DateTime endDate)
        {
            return _totalSales;
        }
    }
}