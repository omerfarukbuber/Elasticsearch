using Elasticsearch.API.Features.ECommerce.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Elasticsearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ECommerceController(IECommerceRepository repository) : ControllerBase
    {
        [HttpGet("term/customer_first_name/{customerFirstName}")]
        public async Task<IActionResult> GetByCustomerFirstName([FromRoute] string customerFirstName)
        {
            var result = await repository.TermSearchByCustomerFirstNameAsync(customerFirstName);
            return Ok(result);
        }

        [HttpPost("terms/customer_first_name")]
        public async Task<IActionResult> GetByCustomerFirstName([FromBody] List<string> customerFirstNames)
        {
            var result = await repository.TermsSearchByCustomerFirstNamesAsync(customerFirstNames);
            return Ok(result);
        }
    }
}
