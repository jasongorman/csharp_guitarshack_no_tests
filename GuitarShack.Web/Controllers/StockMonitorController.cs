using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GuitarShack.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockMonitorController: ControllerBase
    {
        private readonly ILogger<StockMonitorController> _logger;

        public StockMonitorController(ILogger<StockMonitorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public StockCheckResult Get(int productId, int quantity)
        {
            MockAlert alert = new MockAlert();
            StockMonitor monitor = new StockMonitor(
                alert, 
                new ProductWarehouse(
                    new WebService<Product>("https://6hr1390c1j.execute-api.us-east-2.amazonaws.com/default/product")),
                new LeadTimeRestockLevel(
                    new ProductSalesHistory(
                        new WebService<Sales>($"https://gjtvhjg8e9.execute-api.us-east-2.amazonaws.com/default/sales"))));
           
            monitor.HandleSale(productId, quantity);
            
            return new StockCheckResult(){ alertSent = !string.IsNullOrEmpty(alert.Message), message = alert.Message };
        }

        public class MockAlert : IAlert
        {
            public void Send(string message)
            {
                Message = message;
            }

            public string Message { get; private set; }
        }
    }

    public class SaleEvent
    {
        public int productId { get; set; }
        public int quantity { get; set; }
    }

    public class StockCheckResult
    {
        public bool alertSent { get; set; }
        public string message { get; set; }
    }
}