using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineBankingSystem.Dtos;
using OnlineBankingSystem.Repositories;

namespace OnlineBankingSystem.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository<IdentityResult> _repository;

        public UsersController(IUsersRepository<IdentityResult> repository)
        {
            _repository = repository;
        }

        [HttpPost]        
        public async Task<IActionResult> Create([FromBody]RegisterUserDto userDto)
        {
            if(_repository.GetByUserName(userDto.UserName) != null)
            {
                return BadRequest(new { error = "User username already exists" });
            }

            if(_repository.GetByEmail(userDto.Email) != null)
            {
                return BadRequest(new { error = "User email already exists" });
            }

            var result = await _repository.Create(userDto);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(result);
        }
    }
}
