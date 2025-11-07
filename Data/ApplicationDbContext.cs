using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.Data
{
    public class ApplicationDbContext :IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ContactMe> ContactMes{ get; set; }
        public DbSet<Experiance> Experiances { get; set; }
        public DbSet<PrimarySkill> PrimarySkills{ get; set; }
        public DbSet<ProfileDetail> ProfileDetails{ get; set; }
        public DbSet<RefreshToken> RefreshTokens{ get; set; }
        public DbSet<SecondarySkill> SecondarySkills{ get; set; }
        public DbSet<LandingPageDetails> LandingPageDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
