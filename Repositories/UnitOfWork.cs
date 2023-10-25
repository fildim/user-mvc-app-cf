using UserMvcApp.Data;

namespace UserMvcApp.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentsMvc23DbContext _context;

        public UnitOfWork(StudentsMvc23DbContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository => new UserRepository(_context);
        /*
         * public IStudentRepository StudentRepository => new StudentRepository(_context);
         * public ITeacherRepository TeacherRepository => new TeacherRepository(_context);
         * public ICourseRepository CourseRepository => new CourseRepository(_context);
        */


        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
