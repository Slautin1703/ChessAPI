using ChessApi.Models;

namespace ChessApi.UserInterfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsers();
    
    Task<User?> GetUserByIdAsync(int userId);
    Task<User> AddUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(User user);
}