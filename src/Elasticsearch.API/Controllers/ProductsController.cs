using Elasticsearch.API.Features.Products;
using Elasticsearch.API.Features.Products.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Elasticsearch.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAllProducts(IProductService productService)
    {
        var result = await productService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById([FromRoute] string id, IProductService productService)
    {
        var result = await productService.GetByIdAsync(id);
        return result is null
            ? NotFound()
            : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request, IProductService productService)
    {
        var result = await productService.CreateAsync(request);
        return result is null
            ? BadRequest()
            : Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest request, IProductService productService)
    {
        var result = await productService.UpdateAsync(request);
        return result
            ? NoContent()
            : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] string id, IProductService productService)
    {
        var result = await productService.DeleteAsync(id);
        return result
            ? NoContent()
            : NotFound();
    }

} 