
using BlogApiWithASPNetCore.Models;

using Microsoft.EntityFrameworkCore;

namespace BlogApiWithASPNetCore.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>()
                .HasOne(b => b.User)
                .WithMany(a => a.Comments)
                .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<Comment>()
                .HasOne(b => b.Post)
                .WithMany(a => a.Comments)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
