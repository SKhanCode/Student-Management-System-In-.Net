using System.Data.Entity;

namespace StudentManagement.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext() : base("MyDbConnection") { }

        public DbSet<tblCountry> Countries { get; set; }
        public DbSet<tblState> States { get; set; }
        public DbSet<tblCity> Cities { get; set; }
        public DbSet<tblStudent> Students { get; set; }

        // --- NEW TABLES ---
        public DbSet<tblDepartment> Departments { get; set; }
        public DbSet<tblCourse> Courses { get; set; }
    }
}