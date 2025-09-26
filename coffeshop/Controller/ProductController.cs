
using Coffeshop.Models;
using Coffeshop.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Coffeshop.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService service)
        {
            productService = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

    }
}
