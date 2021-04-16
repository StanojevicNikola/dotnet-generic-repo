using Generic.Repo.API.Services;
using Generic.Repo.API.Mapping.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Generic.Repo.API.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }
        
        [HttpGet(ApiRoutes.Get.GetAllOrders)]
        public async Task<ActionResult> GetAllOrders()
        {
            IEnumerable<OrderReadDto> result;

            try
            {
                result = await _service.GetAllOrdersAsync();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(result);
        }

        [HttpGet(ApiRoutes.Get.GetOrder)]
        public async Task<ActionResult> GetOrder(int id)
        {
            OrderReadDto result;

            try
            {
                result = await _service.GetOrderByIdAsync(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(result);
        }

        [HttpPost(ApiRoutes.Post.CreateOrder)]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDto dto)
        {
            OrderReadDto result;

            try
            {
                result = await _service.InsertOrderAsync(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            return StatusCode(StatusCodes.Status201Created, result);
        }

        [HttpPut(ApiRoutes.Put.UpdateOrder)]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderCreateDto dto)
        {
            OrderReadDto result;

            try
            {
                result = await _service.UpdateOrderAsync(id, dto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpDelete(ApiRoutes.Delete.DeleteOrder)]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            OrderReadDto result;

            try
            {
                result = await _service.DeleteOrderAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
