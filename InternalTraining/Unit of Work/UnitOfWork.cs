using InternalTraining.Data;
using InternalTraining.Models;
using InternalTraining.Repositories;
using InternalTraining.Repositories.IRepository;

namespace InternalTraining.Unit_of_Work
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly ApplicationDbContext _context;
        public IRepository<Chapter> Chapters { get; private set; }

        public IRepository<ContactUs> ContactsUs { get; private set; }

        public IRepository<Course> Courses { get; private set; }

        public IRepository<CourseFeedback> CourseFeedbacks { get; private set; }

        public IRepository<EmployeeProgress> EmployeesProgress { get; private set; }

        public IRepository<Exam> Exams { get; private set; }

        public IRepository<Lesson> Lessons { get; private set; }

        public IRepository<Payment> Payments { get; private set; }

        public IRepository<Question> Questions { get; private set; }
        public IRepository<Option> Options { get; private set; }


        public UnitOfWork(ApplicationDbContext _context)
        {
            this._context = _context;
            Chapters = new Repository<Chapter>(_context);
            ContactsUs = new Repository<ContactUs>(_context);
            Courses = new Repository<Course>(_context);
            CourseFeedbacks = new Repository<CourseFeedback>(_context);
            EmployeesProgress = new Repository<EmployeeProgress>(_context);
            Exams = new Repository<Exam>(_context);
            Lessons = new Repository<Lesson>(_context);
            Payments = new Repository<Payment>(_context);
            Questions = new Repository<Question>(_context);
            Questions = new Repository<Question>(_context);

        }
        public void Commit()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose(); 
        }
    }
}
