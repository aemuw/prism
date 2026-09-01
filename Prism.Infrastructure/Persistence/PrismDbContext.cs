using Microsoft.EntityFrameworkCore;
using Prism.Domain.Entities;

namespace Prism.Infrastructure.Persistence
{
    public class PrismDbContext : DbContext
    {
        public PrismDbContext(DbContextOptions<PrismDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Source> Sources => Set<Source>();
        public DbSet<UserSource> UserSources => Set<UserSource>();
        public DbSet<Article> Articles => Set<Article>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<SavedArticle> SavedArticles => Set<SavedArticle>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PrismDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
