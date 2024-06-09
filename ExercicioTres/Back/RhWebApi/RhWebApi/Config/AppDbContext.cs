using Microsoft.EntityFrameworkCore;
using RhWebApi.Models;
namespace RhWebApi.Config
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateTechnology> CandidateTechnologies { get; set; }
        public DbSet<VacancyTechnologyValue> vacancyTechnologyValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidateTechnology>()
                .HasKey(ct => ct.Id);

            modelBuilder.Entity<CandidateTechnology>()
                .HasOne(ct => ct.Candidate)
                .WithMany(c => c.Technologies)
                .HasForeignKey(ct => ct.CandidateId);

            modelBuilder.Entity<CandidateTechnology>()
                .HasOne(ct => ct.Technology)
                .WithMany()
                .HasForeignKey(ct => ct.TechnologyId);

            modelBuilder.Entity<VacancyTechnologyValue>()
                .HasKey(vt => vt.Id);

            modelBuilder.Entity<VacancyTechnologyValue>()
                .HasOne(vt => vt.Vacancy)
                .WithMany(v => v.VacancyTechnologyValues)
                .HasForeignKey(vt => vt.VacancyId);

            modelBuilder.Entity<VacancyTechnologyValue>()
                .HasOne(vt => vt.Technology)
                .WithMany()
                .HasForeignKey(vt => vt.TechnologyId);

            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vacancy>().HasData(
                new Vacancy() { Id = 1, Name = "Vaga Desenvolvedor Backend Pleno", Description = "Vaga Desenvolvedor Backend Pleno" }
                );
            modelBuilder.Entity<Technology>().HasData(
                new Vacancy() { Id = 1, Name = ".Net" },
                new Vacancy() { Id = 2, Name = "Angular" }
                 );

            var candidate = modelBuilder.Entity<Candidate>().HasData(
                new Candidate() { Id = 1, Name = "Leonardo Rizick Buchalla" }
            );
            if (candidate != null)
            {
                modelBuilder.Entity<CandidateTechnology>().HasData(
                    new CandidateTechnology() { Id = 1, CandidateId = 1, TechnologyId = 1 },
                    new CandidateTechnology() { Id = 2, CandidateId = 1, TechnologyId = 2 }
                    );
            }
            modelBuilder.Entity<VacancyTechnologyValue>().HasData(
                new VacancyTechnologyValue() { Id = 1, TechnologyId = 1, VacancyId = 1, Value = 10 },
                new VacancyTechnologyValue() { Id = 2, TechnologyId = 2, VacancyId = 1, Value = 10 }
                );


            // Adicione mais dados de exemplo conforme necessário
        }
    }
}

