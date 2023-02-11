using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OnlineBankingSystem.Dtos;
using OnlineBankingSystem.Entities;

namespace OnlineBankingSystem.Repositories
{
    public class UsersRepository : IUsersRepository<ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UsersRepository(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> Create(RegisterUserDto userDto)
        {
            var user = _mapper.Map<ApplicationUser>(userDto);
            var result = await _userManager.CreateAsync(user, userDto.Password);
            return result;
        }

        public Task<ApplicationUser>? GetByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;

            return _userManager.FindByEmailAsync(email);
        }

        public Task<ApplicationUser>? GetByUserName(string username)
        {
            if (string.IsNullOrEmpty(username))
                return null;

            return _userManager.FindByNameAsync(username);
        }
    }
}
