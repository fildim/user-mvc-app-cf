using UserMvcApp.Data;
using UserMvcApp.DTO;

namespace UserMvcApp.Services
{
    public interface IUserService
    {
        Task SignUpUserAsync(UserSignupDTO request);
        Task<User?> LoginUserAsync(UserLoginDTO credentials);
        Task<User?> UpdateUserAccountInfoAsync(UserPatchDTO request, int userID);
        Task<User?> GetUserByUsername (string username);


    }
}
