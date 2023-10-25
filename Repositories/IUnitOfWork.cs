namespace UserMvcApp.Repositories
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }

        /*
        * public IStudentRepository StudentRepository { get; }
        * public ITeacherRepository TeacherRepository { get; }
        * public ICourseRepository CourseRepository { get; }         
        */

        Task<bool> SaveAsync();



    }
}
