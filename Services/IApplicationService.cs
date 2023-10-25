namespace UserMvcApp.Services
{
    public interface IApplicationService
    {
        IUserService UserService { get; }
        /*
         * IStudentService StudentService { get; }
         * ITeacherService TeacherService { get; }
         * ICourseService CourseService { get; }
         */
    }
}
