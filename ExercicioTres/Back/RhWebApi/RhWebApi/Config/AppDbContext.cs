using Microsoft.EntityFrameworkCore;
using RhWebApi.Models;
using RhWebApi.Repositories;
using System.Xml.Linq;
namespace RhWebApi.Config
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateTechnology> CandidateTechnologies { get; set; }
        public DbSet<VacancyTechnologyValue> vacancyTechnologyValues { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>().HasOne(c => c.Vacancy).WithMany().HasForeignKey(c => c.VacancyId);
            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vacancy>().HasData(new Vacancy() { Id = 1, Name = "Vaga Desenvolvedor Backend Pleno", Description = "Vaga reservada a Leonardo Rizick Buchalla" });
            modelBuilder.Entity<Technology>().HasData(new Technology() { Id = 1, Name = ".Net" }, new Technology() { Id = 2, Name = "Angular" });
            modelBuilder.Entity<Candidate>().HasData(new Candidate() { Id = 1, Name = "Leonardo Rizick Buchalla", VacancyId = 1});
        }
    }
}

