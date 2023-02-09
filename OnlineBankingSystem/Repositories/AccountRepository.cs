using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OnlineBankingSystem.Dtos;
using OnlineBankingSystem.Entities;

namespace OnlineBankingSystem.Repositories
{
    public class AccountRepository : IAccountRepository<IdentityResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AccountRepository(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> Register(RegisterUserDto userDto)
        {
            var user = _mapper.Map<ApplicationUser>(userDto);
            var result = await _userManager.CreateAsync(user, userDto.Password);
            return result;
        }
    }
}
