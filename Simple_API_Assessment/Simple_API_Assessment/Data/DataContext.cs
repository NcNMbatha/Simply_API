using Microsoft.EntityFrameworkCore;
using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options) :base(options)
        { 

        }

        public DbSet<Applicant> Applicant { get; set; }
        public DbSet<Skill> Skill { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Table Applicant
            modelBuilder.Entity<Applicant>().HasData(new Applicant { Id = 1, Name = "Njabulo Nhlanhla Mbatha" });

            // Seed data for Table Skill
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = ".Net Framework", ApplicantId = 1 },
                new Skill { Id = 2, Name = "Angular", ApplicantId = 1 },
                new Skill { Id = 3, Name = "SQL Server", ApplicantId = 1 }
            );
        }
    }
}
