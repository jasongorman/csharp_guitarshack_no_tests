using System;
using System.Collections.Generic;

namespace GuitarShack
{
    public class ProductSalesHistory : ISalesHistory
    {
        private readonly WebService<Sales> _service;

        public ProductSalesHistory(WebService<Sales> service)
        {
            _service = service;
        }

        public int Total(int productId, DateTime startDate, DateTime endDate)
        {
            Dictionary<string, string> queryParams = new Dictionary<string, string>
            {
                ["productId"] = productId.ToString(),
                ["startDate"] = startDate.ToString("M/d/yyyy"),
                ["endDate"] = endDate.ToString("M/d/yyyy"),
                ["action"] = "total"
            };
            var sales = _service.Fetch(queryParams);
            return sales.total;
        }
    }
}