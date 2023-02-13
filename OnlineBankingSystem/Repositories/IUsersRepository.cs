using Microsoft.AspNetCore.Identity;
using OnlineBankingSystem.Dtos;
using OnlineBankingSystem.Responses;

namespace OnlineBankingSystem.Repositories
{
    public interface IUsersRepository<T>
    {
        Task<IdentityResult> Create(RegisterUserDto userDto);
        Task<T?> GetByUserName(string? username);
        Task<T?> GetByEmail(string? email);
        Task<bool> VerifyPassword(T user, string? password);
    }
}
