using InternalTraining.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using InternalTraining.Models.ViewModel;

namespace InternalTraining.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Chapter> Chapters { get; }
        public DbSet<ContactUs> ContactsUs { get; }
        public DbSet<Option> Options { get; }
        public DbSet<Course> Courses { get; }
        public DbSet<CourseFeedback> CourseFeedbacks { get; }
        public DbSet<EmployeeProgress> EmployeesProgress { get; }
        public DbSet<Exam> Exams { get; }
        public DbSet<Lesson> Lessons { get; }
        public DbSet<Payment> Payments { get; }
        public DbSet<Question> Questions { get; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.Entity<CompanyCourse>().HasKey(e => new { e.CompanyId, e.CourseId });
        }
        public DbSet<InternalTraining.Models.ViewModel.RegisterVm> RegisterVm { get; set; } = default!;
        public DbSet<InternalTraining.Models.ViewModel.LoginVm> LoginVm { get; set; } = default!;
        public DbSet<InternalTraining.Models.ViewModel.ForgetPasswordVm> ForgetPasswordVm { get; set; } = default!;
        public DbSet<InternalTraining.Models.ViewModel.ResetPasswordVm> ResetPasswordVm { get; set; } = default!;
        public DbSet<InternalTraining.Models.ViewModel.ProfileVm> ProfileVm { get; set; } = default!;
    }
}
