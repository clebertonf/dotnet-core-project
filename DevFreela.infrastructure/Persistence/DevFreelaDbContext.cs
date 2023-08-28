using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.infrastructure.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base (options)
        {
           
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Freelancer)
                .WithMany(p => p.FreeLanceProjects)
                .HasForeignKey(p => p.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Client)
                .WithMany(p => p.OwnedProjects)
                .HasForeignKey(p => p.IdClient)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectComment>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<ProjectComment>()
                .HasOne(p => p.Project)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.idProject)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectComment>()
               .HasOne(p => p.User)
               .WithMany(p => p.Comments)
               .HasForeignKey(p => p.idUser)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Skill>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<User>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Skills)
                .WithOne()
                .HasForeignKey(u => u.IdSkill)
                .OnDelete(DeleteBehavior.Restrict); ;

            modelBuilder.Entity<UserSkill>()
                .HasKey(p => p.Id);
        }
    }
}
