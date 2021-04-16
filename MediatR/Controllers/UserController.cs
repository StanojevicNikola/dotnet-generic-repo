using Generic.Repo.API.Mapping.Dtos;
using Generic.Repo.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Generic.Repo.API.Controllers
{
    //[Route(ApiRoutes.users)]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        
        [HttpGet(ApiRoutes.Get.GetAllUsers)]
        public async Task<ActionResult> GetAllUsers()
        {
            IEnumerable<UserReadDto> result;

            try
            {
                result = await _service.GetAllUsersAsync();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(result);
        }

        [HttpGet(ApiRoutes.Get.GetUser)]
        public async Task<ActionResult> GetUser(int id)
        {
            UserReadDto result;

            try
            {
                result = await _service.GetUserByIdAsync(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(result);
        }

        [HttpPost(ApiRoutes.Post.CreateUser)]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto dto)
        {
            UserReadDto result;

            try
            {
                result = await _service.InsertUserAsync(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            return StatusCode(StatusCodes.Status201Created, result);
        }

        [HttpPut(ApiRoutes.Put.UpdateUser)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserCreateDto dto)
        {
            UserReadDto result;

            try
            {
                result = await _service.UpdateUserAsync(id, dto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpDelete(ApiRoutes.Delete.DeleteUser)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            UserReadDto result;

            try
            {
                result = await _service.DeleteUserAsync(id);   
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
