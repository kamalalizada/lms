using Microsoft.AspNetCore.Mvc;
using Business.Concrete;
using Entity.Concrete;
using Entity.Dto;

namespace LMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            var dto = users.Select(u => new UserDto
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email
            }).ToList();

            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();

            var dto = new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateUserDto dto)
        {
            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Password = dto.Password 
            };

            await _userService.AddAsync(user);
            return Ok(new { message = "User created successfully" });
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserDto dto)
        {
            var user = await _userService.GetByIdAsync(dto.Id);
            if (user == null) return NotFound();

            user.FullName = dto.FullName;
            user.Email = dto.Email;

            if (!string.IsNullOrEmpty(dto.Password))
            {
                user.Password = dto.Password; 
            }

            await _userService.UpdateAsync(user);
            return Ok(new { message = "User updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();

            await _userService.DeleteAsync(id);
            return Ok(new { message = "User deleted successfully" });
        }
    }
}
