using AutoMapper;
using UserMvcApp.Data;
using UserMvcApp.DTO;
using UserMvcApp.Repositories;

namespace UserMvcApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }




        public async Task SignUpUserAsync(UserSignupDTO request)
        {
            if (!await _unitOfWork.UserRepository.SignUpUserAsync(request))
            {
                throw new ApplicationException("User already exists");
            }

            await _unitOfWork.SaveAsync();
        }


        public async Task<User?> LoginUserAsync(UserLoginDTO credentials)
        {
            var user = await _unitOfWork.UserRepository.GetUserAsync(credentials.Username!, credentials.Password!);
            
            if (user == null) return null;

            return user;
        }


        public async Task<User?> UpdateUserAccountInfoAsync(UserPatchDTO request, int userID)
        {
            var user = await _unitOfWork.UserRepository.UpdateUserAsync(userID, request);

            await _unitOfWork.SaveAsync();

            return user;
        }



        public async Task<User?> GetUserByUsername(string username)
        {
            return await _unitOfWork.UserRepository.GetByUsernameAsync(username);
        }

        
    }
}
