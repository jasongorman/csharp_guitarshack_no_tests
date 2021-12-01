using System;

namespace GuitarShack
{
    public class LeadTimeRestockLevel : IRestockLevel
    {
        private readonly ISalesHistory _salesHistory;

        public LeadTimeRestockLevel(ISalesHistory salesHistory)
        {
            _salesHistory = salesHistory;
        }

        public int Calculate(Product product)
        {
            int totalSales = _salesHistory.Total(product.id, DateTime.Today.AddDays(-30), DateTime.Today);

            double averageDailySales = totalSales / 30.0;
            return (int) Math.Ceiling(product.leadTime * averageDailySales);
        }
    }
}