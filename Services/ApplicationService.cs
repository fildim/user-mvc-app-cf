using AutoMapper;
using UserMvcApp.Repositories;

namespace UserMvcApp.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApplicationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IUserService UserService => new UserService(_unitOfWork, _mapper);
        /*
         * public IStudentService StudentService => new StudentService(_unitOfWork, _mapper);
         * public ITeacherService TeacherService => new TeacherService(_unitOfWork, _mapper);
         * public ICourseService CourseService => new CourseService(_unitOfWork, _mapper);
         */


    }
}
