using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OnlineBankingSystem.Dtos;
using OnlineBankingSystem.Entities;
using OnlineBankingSystem.Enums;
using OnlineBankingSystem.Responses;

namespace OnlineBankingSystem.Repositories
{
    public class UsersRepository : IUsersRepository<ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public UsersRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> Create(RegisterUserDto userDto)
        {
            var user = _mapper.Map<ApplicationUser>(userDto);
            var result = await _userManager.CreateAsync(user, userDto.Password);
            if (result.Succeeded)
            {
                await AssignRole(user, Roles.User.ToString());
            }
            return result;
        }

        private async Task AssignRole(ApplicationUser user, string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role != null)
            {
                await _userManager.AddToRoleAsync(user, roleName);
            }
            else
            {
                throw new Exception("Role is not created");
            }
        }

        public async Task<ApplicationUser?> GetByEmail(string? email)
        {
            if (string.IsNullOrEmpty(email))
                return null;

            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<ApplicationUser?> GetByUserName(string? username)
        {
            if (string.IsNullOrEmpty(username))
                return null;

            return await _userManager.FindByNameAsync(username);
        }

        public async Task<bool> VerifyPassword(ApplicationUser user, string? password)
        {
            if(user == null)
                return false;

            if (string.IsNullOrEmpty(password))
                return false;

            return await _userManager.CheckPasswordAsync(user, password);
        }
    }
}
