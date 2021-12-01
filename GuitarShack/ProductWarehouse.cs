using System.Collections.Generic;

namespace GuitarShack
{
    public class ProductWarehouse : IWarehouse
    {
        private readonly WebService<Product> _service;

        public ProductWarehouse(WebService<Product> service)
        {
            _service = service;
        }

        public Product GetProduct(in int productId)
        {
            Dictionary<string, string> queryParams = new Dictionary<string, string> {["id"] = productId.ToString()};
            return _service.Fetch(queryParams);
        }
    }
}