using InternalTraining.Data;
using InternalTraining.Models;
using InternalTraining.Repositories;
using InternalTraining.Repositories.IRepository;

namespace InternalTraining.Unit_of_Work
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Chapter> Chapters { get; }
        IRepository<ContactUs> ContactsUs { get; }

        IRepository<Course> Courses { get; }
        IRepository<CourseFeedback> CourseFeedbacks { get; }
        IRepository<EmployeeProgress> EmployeesProgress { get; }
        IRepository<Exam> Exams { get; }
        IRepository<Lesson> Lessons { get; }
        IRepository<Payment> Payments { get; }
        IRepository<Question> Questions { get; }
        IRepository<AnswerOption> AnswerOptions { get; }
        
        void Commit();

    }
}
