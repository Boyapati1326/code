using Microsoft.AspNetCore.Mvc;
using Pinnacle.PIS.Server.Domain;
using Pinnacle.PIS.Server.Services.ProductService;

namespace Pinnacle.PIS.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private IProductService _productService;
        private ILogger<ProductController> _logger;
        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _logger = logger;
            _productService = productService;
        }
        [HttpPost]
        public async Task<bool> loadNewBatchAsync(List<ImportedData> productInfos)
        {
            return await _productService.LoadNewBatchAsync(productInfos);
        }
    }
}
