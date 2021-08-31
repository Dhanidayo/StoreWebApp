using System;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreManagement.BL;
using StoreManagement.DB;
using StoreManagement.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductRequest addProductRequest)
        {
            try
            {
                var result = await _productService.AddProduct(addProductRequest.ProductName, addProductRequest.Price, addProductRequest.StoreId);

                return CreatedAtAction(nameof(GetProduct), new {StoreId = addProductRequest.StoreId}, result);
            }
            catch (Exception)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetProduct([FromQuery] string productId)
        {
            try
            {
                var result = await _productService.GetProduct(productId);
                return Ok(result);
            }
            catch (ArgumentException)
            {   
                //logging error
                return NotFound("Resource does not exist");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Store>> DeleteProduct([FromQuery] string productId)
        {
            try
            {
                var result = await _productService.DeleteProduct(productId);
                if (result)
                {
                    return NoContent();
                }

                return NotFound("Resource not found");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateProduct([FromQuery] string productId, string storeId, UpdateProductRequest updateProductRequest)
        {
            try
            {
                var result = await _productService.UpdateProduct(productId, storeId, updateProductRequest);
                if (result)
                {
                    return NoContent();
                }

                return NotFound("Resource not found");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}