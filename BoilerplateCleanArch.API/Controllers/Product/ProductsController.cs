using BoilerplateCleanArch.Application.DTOS.Product;
using BoilerplateCleanArch.Application.Interfaces.IProductService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoilerplateCleanArch.API.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productsService;
        public ProductsController(IProductService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var productDTOs = await _productsService.GetProducts();

            if (productDTOs == null)
                return NotFound("Products not found");

            return Ok(productDTOs);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> GetById(int id)
        {
            var productDTOs = await _productsService.GetById(id);

            if (productDTOs == null)
                return NotFound("Product not found");

            return Ok(productDTOs);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
        {
            if (productDTO == null)
                return BadRequest("Invalid Data");

            await _productsService.Add(productDTO);

            return new CreatedAtRouteResult("GetProduct", new { id = productDTO.Id }, productDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDTO)
        {
            if (id != productDTO.Id)
                return BadRequest();

            if (productDTO == null)
                return BadRequest();

            await _productsService.Update(productDTO);

            return Ok(productDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var productDTO = await _productsService.GetById(id);

            if (productDTO == null)
                return NotFound("Category not found");

            await _productsService.Remove(productDTO.Id);

            return Ok(productDTO);
        }
    }
}
