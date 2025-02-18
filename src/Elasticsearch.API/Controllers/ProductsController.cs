using Elasticsearch.API.Features.Products;
using Elasticsearch.API.Features.Products.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Elasticsearch.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request, IProductService productService)
    {
        var result = await productService.CreateAsync(request);
        return result is null
            ? BadRequest()
            : Created("", result);
    }

} 