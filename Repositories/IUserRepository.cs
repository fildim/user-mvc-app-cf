using UserMvcApp.Data;
using UserMvcApp.DTO;

namespace UserMvcApp.Repositories
{
    public interface IUserRepository
    {
        Task<bool> SignUpUserAsync(UserSignupDTO request);
        Task<User?> GetUserAsync(string username, string password);
        Task<User?> UpdateUserAsync(int userId, UserPatchDTO request);
        Task<User?> GetByUsernameAsync(string username);
    }
}
