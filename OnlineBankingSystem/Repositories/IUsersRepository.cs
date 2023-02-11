using OnlineBankingSystem.Dtos;

namespace OnlineBankingSystem.Repositories
{
    public interface IUsersRepository<T>
    {
        Task<T> Register(RegisterUserDto userDto);
    }
}
