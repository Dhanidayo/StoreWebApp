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
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService ?? throw new ArgumentNullException(nameof(storeService));
        }

        [HttpGet]
        public async Task<ActionResult> GetStore([FromQuery] string storeId)
        {
            try
            {
                var result = await _storeService.GetStore(storeId);
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

        [HttpPost]
        public async Task<IActionResult> AddStore(AddStoreRequest addStoreRequest)
        {
            try
            {
                var result = await _storeService.AddStore(addStoreRequest.StoreName, addStoreRequest.Products, addStoreRequest.UserId, addStoreRequest.Location, addStoreRequest.Branches);

                return CreatedAtAction(nameof(GetStore), new {UserId = addStoreRequest.UserId}, result);
            }
            catch (Exception)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Store>> DeleteStore([FromQuery] string storeId, string userId)
        {
            try
            {
                var result = await _storeService.DeleteStore(storeId, userId);
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

        [HttpPut]
        public async Task<IActionResult> UpdateStore_Put(StorePutRequest putRequest, [FromQuery] string storeId, string userId)
        {
            try
            {
                var result = await _storeService.UpdateStore_Put(putRequest, storeId, userId);
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
        public async Task<IActionResult> UpdateStore_Patch(StorePatchRequest patchRequest, [FromQuery] string storeId, string userId)
        {
            try
            {
                var result = await _storeService.UpdateStore_Patch(patchRequest, storeId, userId);

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