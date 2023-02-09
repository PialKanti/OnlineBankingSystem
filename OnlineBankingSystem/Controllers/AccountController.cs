using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineBankingSystem.Dtos;
using OnlineBankingSystem.Repositories;

namespace OnlineBankingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository<IdentityResult> _repository;

        public AccountController(IAccountRepository<IdentityResult> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult<IdentityResult> Register([FromBody]RegisterUserDto userDto)
        {
            var result = _repository.Register(userDto);

            if(!result.IsCompleted)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(result);
        }
    }
}
