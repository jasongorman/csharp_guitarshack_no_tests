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

        [HttpPost]
        public StockCheckResult Post(SaleEvent sale)
        {
            return new StockCheckResult() {alertSent = false, message = ""};
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