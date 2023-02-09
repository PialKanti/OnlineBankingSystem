using OnlineBankingSystem.Dtos;

namespace OnlineBankingSystem.Repositories
{
    public interface IAccountRepository<T>
    {
        Task<T> Register(RegisterUserDto userDto);
    }
}
